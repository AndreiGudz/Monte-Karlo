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

        private Point CircleCenter = new Point(3, 1);
        private float radius = 2;
        private Direction direction = Direction.horizontal;
        private float C = 2;
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
            radiusTrackBar.Value = (int)radius;
            radiusLabel.Text = $"Radius: {radiusTrackBar.Value}";

            scaleTrackBar.Value = MonteCarloView.GridStep;
            scaleLabel.Text = $"Scale: {scaleTrackBar.Value}";

            SetCTrackBarBorders();
            cTrackBar.Value = Convert.ToInt32(C * cofficient);
            cLabel.Text = $"C: {C}";

            pointsCountUpdown.Maximum = int.MaxValue - 1;
            pointsCountUpdown.Value = pointsCount;
        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            MonteCarloView.RenderToBuffer(paintPanel, e, radius, CircleCenter, direction, C);

            base.OnPaint(e);
        }

        private void radiusSlider_Scroll(object sender, EventArgs e)
        {
            radiusLabel.Text = $"Radius: {radiusTrackBar.Value}";
            radius = (float)radiusTrackBar.Value;
            SetCTrackBarBorders();

            GenerateRandomPoints();
        }

        private void SetCTrackBarBorders()
        {
            int border = Convert.ToInt32(radius * cofficient);
            int min, max;
            if (direction == Direction.vertical)
            {
                min = -border + CircleCenter.X * (int)cofficient;
                max = border + CircleCenter.X * (int)cofficient;
            }
            else
            {
                min = -border + CircleCenter.Y * (int)cofficient;
                max = border + CircleCenter.Y * (int)cofficient;
            }
            C = Math.Clamp(C * cofficient, min, max) * divisionScale;
            cTrackBar.Minimum = min;
            cTrackBar.Maximum = max;
            cLabel.Text = $"C: {C}";
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
            C = cTrackBar.Value * divisionScale;
            cLabel.Text = $"C: {C}";

            GenerateRandomPoints();
        }

        private void GeneratePointsButton_Click(object sender, EventArgs e)
        {
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
                await PointsGenerator.GenerateRandomPointsAsync(radius, pointsCount,
                    CircleCenter, direction, C, token);
                if (token.IsCancellationRequested)
                    return;

                paintPanel.Invalidate();

                var realSquare = Calculator.CalculateIntegralArea(CircleCenter, radius, direction, C);
                var monteCarloSquare = Calculator.CalculateMonteCarloArea(radius);
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
                Circle square: {Calculator.CircleSuare(radius)}
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

        private void horizontalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (direction == Direction.horizontal)
                direction = Direction.vertical;
            else
                direction = Direction.horizontal;

            SetCTrackBarBorders();
            paintPanel.Invalidate();
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
