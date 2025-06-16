using Monte_Karlo.Calculators;
using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Karlo
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _generationCts;
        private float cofficient = 2, divisionScale = 0.5f;
        public Circle circle = new Circle();

        private int pointsCount = 100_000;

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, paintPanel, new object[] { true });
            InitializeControlPanel();
            DatabaseHelper.InitializeDatabase();
        }

        private void InitializeControlPanel()
        {
            xNumericUpDown.Value = circle.circleCenter.X;
            yNumericUpDown.Value = circle.circleCenter.Y;

            radiusTrackBar.Value = (int)circle.radius;
            radiusLabel.Text = $"Радиус круга: {radiusTrackBar.Value}";
            SetCTrackBarBorders();

            scaleTrackBar.Value = MonteCarloView.GridStep;
            scaleLabel.Text = $"Масштаб: {scaleTrackBar.Value}";

            cTrackBar.Value = Convert.ToInt32(circle.C * cofficient);
            cLabel.Text = $"Значение C: {circle.C}";

            pointsCountUpdown.Value = pointsCount;
        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                MonteCarloView.RenderToBuffer(paintPanel, e, circle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка из-за частой переотрисовки графика.\n" +
                    "Пожалуйста, дайте вермя на переотрисовку графика", "Ошбика");
                Thread.Sleep(100);
                MonteCarloView.RenderToBuffer(paintPanel, e, circle);
            }

            base.OnPaint(e);
        }

        private async void radiusSlider_Scroll(object sender, EventArgs e)
        {
            radiusLabel.Text = $"Радиус круга: {radiusTrackBar.Value}";
            circle.radius = (float)radiusTrackBar.Value;
            SetCTrackBarBorders();

            await GenerateRandomPoints();
        }

        private void SetCTrackBarBorders()
        {
            int border = Convert.ToInt32(circle.radius * cofficient);
            int min, max;
            if (circle.direction == Direction.vertical)
            {
                min = -border + circle.circleCenter.X * (int)cofficient;
                max = border + circle.circleCenter.X * (int)cofficient;
            }
            else
            {
                min = -border + circle.circleCenter.Y * (int)cofficient;
                max = border + circle.circleCenter.Y * (int)cofficient;
            }
            circle.C = Math.Clamp(circle.C * cofficient, min, max) * divisionScale;
            cTrackBar.Minimum = min;
            cTrackBar.Maximum = max;
            cLabel.Text = $"Значение C: {circle.C}";
        }

        private void scaleTrackbar_Scroll(object sender, EventArgs e)
        {
            scaleLabel.Text = $"Масштаб: {scaleTrackBar.Value}";
            MonteCarloView.GridStep = scaleTrackBar.Value;

            paintPanel.Invalidate();
        }

        private async void pointsCountUpdown_ValueChanged(object sender, EventArgs e)
        {
            pointsCount = (int)pointsCountUpdown.Value;

            await GenerateRandomPoints();
        }

        private async void cTrackbar_ValueChanged(object sender, EventArgs e)
        {
            circle.C = cTrackBar.Value * divisionScale;
            cLabel.Text = $"Значение C: {circle.C}";
            await ViewCutedPoints();
        }

        private async void GeneratePointsButton_Click(object sender, EventArgs e) => await GenerateRandomPoints();

        private async void horizontalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (circle.direction == Direction.horizontal)
                circle.direction = Direction.vertical;
            else
                circle.direction = Direction.horizontal;

            SetCTrackBarBorders();
            await ViewCutedPoints();
        }

        private async Task ViewCutedPoints()
        {
            if (PointsGenerator.Points.Count == 0)
            {
                await GenerateRandomPoints();
                return;
            }

            if (this.Visible != true)
                return;

            _generationCts?.Cancel();
            _generationCts = new CancellationTokenSource();

            try
            {
                var token = _generationCts.Token;
                var parallelOptions = new ParallelOptions { CancellationToken = token };
                await Task.Run(() =>
                    PointsGenerator.CalculateCuttedPoints(circle, parallelOptions)
                );
                if (token.IsCancellationRequested)
                    return;

                paintPanel.Invalidate();

                var realSquare = Calculator.CalculateAnalyticArea(circle);
                var monteCarloSquare = Calculator.CalculateMonteCarloArea(circle.radius);

                ShowAnswereMessage(realSquare, monteCarloSquare);

                WriteResultOnLabels(realSquare, monteCarloSquare);
                DatabaseHelper.SaveResults(
                    circle,
                    pointsCount,
                    PointsGenerator.IncludedPoints.Count,
                    PointsGenerator.CuttedPoints.Count,
                    realSquare,
                    monteCarloSquare);
            }
            catch (OperationCanceledException)
            {
                // Игнорируем отмену
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async Task GenerateRandomPoints()
        {
            if (this.Visible != true)
                return;

            _generationCts?.Cancel();
            _generationCts = new CancellationTokenSource();

            try
            {
                var token = _generationCts.Token;
                await PointsGenerator.GenerateRandomPointsAsync(circle, pointsCount, token);
                if (token.IsCancellationRequested)
                    return;

                paintPanel.Invalidate();

                var realSquare = Calculator.CalculateAnalyticArea(circle);
                var monteCarloSquare = Calculator.CalculateMonteCarloArea(circle.radius);

                ShowAnswereMessage(realSquare, monteCarloSquare);
                WriteResultOnLabels(realSquare, monteCarloSquare);
                DatabaseHelper.SaveResults(
                    circle,
                    pointsCount,
                    PointsGenerator.IncludedPoints.Count,
                    PointsGenerator.CuttedPoints.Count,
                    realSquare,
                    monteCarloSquare);
            }
            catch (OperationCanceledException)
            {
                // Игнорируем отмену
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void WriteResultOnLabels(double realSquare, double monteCarloSquare)
        {
            realSquareLabel.Text = $"Площадь секции аналитически: {realSquare:F3}";
            monteCarloSquareLabel.Text = $"Площадь методом Монте-Карло: {monteCarloSquare:F3}";
        }

        private void ShowAnswereMessage(double realSquare, double monteCarloSquare)
        {
            if (!showMessageCheckBox.Checked)
                return;

            double roundRelativeError = Math.Round(Calculator.CalculateRelativeError(realSquare, monteCarloSquare), 3);
            double roundAbsoluteError = Math.Round(Calculator.CalculateAbsoluteError(realSquare, monteCarloSquare), 3);
            string message = $"""
            Площадь круга: {Calculator.CircleSuare(circle.radius):F3}
            Всего точек: {PointsGenerator.Points.Count}
            Количество точек попавших в круг {PointsGenerator.IncludedPoints.Count}
            Количество точек в большей секции: {PointsGenerator.CuttedPoints.Count}
            Площадь секции аналитически: {realSquare:F3}
            Площадь секции методом Монте-Карло: {monteCarloSquare:F3}
            Абсолютаня погрешность вычислений: {roundAbsoluteError}
            Относительная погрешность вычислений: {roundRelativeError}%
            """;
            MessageBox.Show(message, "Результат вычислений");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _generationCts?.Cancel();
            Application.Exit();
        }

        private void programHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutProgramForm();
            form.ShowDialog();
        }

        private void очиститьТочкиButton_Click(object sender, EventArgs e)
        {
            PointsGenerator.ClearPoints();
            paintPanel.Invalidate();
            WriteResultOnLabels(0, 0);
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private async void xNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            circle.circleCenter.X = (int)Math.Floor(xNumericUpDown.Value);
            SetCTrackBarBorders();
            await ViewCutedPoints();
        }

        private async void yNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            circle.circleCenter.Y = (int)Math.Floor(yNumericUpDown.Value);
            SetCTrackBarBorders();
            await ViewCutedPoints();
        }

        private void анализСохранённныхРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var circleParam = DatabaseHelper.GetData(circle, pointsCount);
            var form = new AnalysisForm(circleParam);
            form.ShowDialog();
        }

        private void paintPanel_Resize(object sender, EventArgs e)
        {
            paintPanel.Invalidate();
        }
    }
}
