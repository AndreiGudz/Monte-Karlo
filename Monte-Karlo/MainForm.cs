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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Monte_Karlo
{
    public partial class MainForm : Form
    {
        private static NotifyIcon notifyIcon = new NotifyIcon();
        private CancellationTokenSource _generationCts;
        private float cofficient = 2, divisionScale = 0.5f;
        private Circle circle = new Circle();

        private int pointsCount = 100_000;
        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, paintPanel, new object[] { true });
            InitializeControlPanel();
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
        }

        private void InitializeControlPanel()
        {
            radiusTrackBar.Value = (int)circle.radius;
            radiusLabel.Text = $"Radius: {radiusTrackBar.Value}";

            scaleTrackBar.Value = MonteCarloView.GridStep;
            scaleLabel.Text = $"Scale: {scaleTrackBar.Value}";

            SetCTrackBarBorders();
            cTrackBar.Value = Convert.ToInt32(circle.C * cofficient);
            cLabel.Text = $"C: {circle.C}";

            pointsCountUpdown.Maximum = int.MaxValue - 1;
            pointsCountUpdown.Value = pointsCount;
        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            MonteCarloView.RenderToBuffer(paintPanel, e, circle);

            base.OnPaint(e);
        }

        private void radiusSlider_Scroll(object sender, EventArgs e)
        {
            radiusLabel.Text = $"Radius: {radiusTrackBar.Value}";
            circle.radius = (float)radiusTrackBar.Value;
            SetCTrackBarBorders();

            GenerateRandomPoints();
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
            cLabel.Text = $"C: {circle.C}";
        }

        private void scaleTrackbar_Scroll(object sender, EventArgs e)
        {
            scaleLabel.Text = $"Scale: {scaleTrackBar.Value}";
            MonteCarloView.GridStep = scaleTrackBar.Value;

            paintPanel.Invalidate();
        }

        private void pointsCountUpdown_ValueChanged(object sender, EventArgs e)
        {
            pointsCount = (int)pointsCountUpdown.Value;

            GenerateRandomPoints();
        }

        private void cTrackbar_ValueChanged(object sender, EventArgs e)
        {
            circle.C = cTrackBar.Value * divisionScale;
            cLabel.Text = $"C: {circle.C}";

            GenerateRandomPoints();
        }

        private void GeneratePointsButton_Click(object sender, EventArgs e)
        {
            GenerateRandomPoints();
        }

        private void horizontalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (circle.direction == Direction.horizontal)
                circle.direction = Direction.vertical;
            else
                circle.direction = Direction.horizontal;

            SetCTrackBarBorders();
            GenerateRandomPoints();
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
                ShowNotify(realSquare, monteCarloSquare);
                realSquareLabel.Text = $"Real Square: {realSquare:F6}";
                MonteCarloSquare.Text = $"Monte Carlo Square: {monteCarloSquare:F6}";
            }
            catch (OperationCanceledException)
            {
                // Игнорируем отмену
            }
            catch (Exception ex)
            {
                notifyIcon.Text = ex.Message;
                notifyIcon.BalloonTipTitle = "Error";
                notifyIcon.ShowBalloonTip(3);
            }
        }

        private void ShowNotify(double realSquare, double monteCarloSquare)
        {
            if (showMessageCheckBox.Checked)
            {
                string message = $"""
                Circle square: {Calculator.CircleSuare(circle.radius)}
                All points count: {PointsGenerator.Points.Count}
                Into circle points count {PointsGenerator.IncludedPoints.Count}
                Cuted asea points count: {PointsGenerator.CuttedPoints.Count}
                Real area square: {realSquare:F6}
                Monte Carlo area square: {monteCarloSquare:F6}
                """;
                MessageBox.Show(message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
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

        private void сгенерироватьТочкиToolStripMenuItem_Click(object sender, EventArgs e) => GenerateRandomPoints();

        private void очиститьТочкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsGenerator.ClearPoints();
            paintPanel.Invalidate();
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
    }
}
