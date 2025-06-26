// Основная форма программы для ввода параметров расчёта площади сегмента круга
// методом Монте-Карло и визуализации результатов
using Monte_Karlo.DataBase;
using Monte_Karlo.Forms;
using Monte_Karlo.Models;
using Monte_Karlo.Utilites.Calculators;
using Monte_Karlo.Utilites.View;
using Monte_Karlo.Utilites;
using System.Diagnostics;
using System.Reflection;

namespace Monte_Karlo
{
    public partial class MainForm : Form
    {
        private float cofficient = 2, divisionScale = 0.5f;
        private Circle circle = new Circle();
        private int pointsCount = 100_000;

        private CancellationTokenSource _generationCts;
        private PointsGenerator _pointsGenerator;
        private MonteCarloView _view;
        private DatabaseHelper _databaseHelper;
        private Logger _logger;

        // Инициализирует главную форму и компоненты
        public MainForm()
        {
            InitializeComponent();
            _pointsGenerator = new PointsGenerator();
            _databaseHelper = new DatabaseHelper();
            _view = new MonteCarloView();
            _logger = new Logger();

            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, paintPanel, new object[] { true });
            InitializeControlPanel();
            _databaseHelper.InitializeDatabase();
            _logger.Log("Приложение запущено");
        }

        // Настраивает начальные значения элементов управления
        private void InitializeControlPanel()
        {
            xNumericUpDown.Value = circle.circleCenter.X;
            yNumericUpDown.Value = circle.circleCenter.Y;

            radiusTrackBar.Value = (int)circle.radius;
            radiusLabel.Text = $"Радиус круга: {radiusTrackBar.Value}";
            SetCTrackBarBorders();

            scaleTrackBar.Value = _view.GridStep;
            scaleLabel.Text = $"Масштаб: {scaleTrackBar.Value}";

            cTrackBar.Value = Convert.ToInt32(circle.C * cofficient);
            cLabel.Text = $"Значение C: {circle.C}";

            pointsCountUpdown.Value = pointsCount;
        }

        // Выполняет расчёт методом Монте-Карло
        private async Task MonteCarloCalculate(bool generateNewPoints)
        {
            if (this.Visible != true)
                return;

            _generationCts?.Cancel();
            _generationCts = new CancellationTokenSource();

            try
            {
                var token = _generationCts.Token;

                // Генерировать новые точки или переобработать старые
                if (generateNewPoints)
                {
                    await _pointsGenerator.GenerateRandomPointsAsync(circle, pointsCount, token);
                }
                else
                {
                    await _pointsGenerator.CalculateCuttedPointsAsync(circle, pointsCount, token);
                }

                if (token.IsCancellationRequested)
                    return;

                // Переотрисовка
                paintPanel.Invalidate();

                // Расчёты
                double realSquare = Calculator.CalculateAnalyticArea(circle);
                var roundedRealSquare = Math.Round(realSquare, 4);

                var currentPoints = _pointsGenerator.GetCurrentPoints();
                double monteCarloSquare = Calculator.CalculateMonteCarloArea(
                    circle.radius,
                    currentPoints.Points.Count,
                    currentPoints.CuttedPoints.Count);
                var roundedMonteCarloSquare = Math.Round(monteCarloSquare, 4);

                // Вывод результатов
                ShowAnswereMessage(realSquare, monteCarloSquare, currentPoints);
                _logger.Log($"Сделаны расчёты с параметрами: {circle.ToString()} и количеством точек {pointsCount}");
                WriteResultOnLabels(roundedRealSquare, roundedMonteCarloSquare);
                // Сохранение в БД
                _databaseHelper.SaveResults(
                    circle,
                    currentPoints,
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

        // Выводит результаты расчётов на метки формы
        private void WriteResultOnLabels(double realSquare, double monteCarloSquare)
        {
            realSquareLabel.Text = $"Площадь секции аналитически: {realSquare:F4}";
            monteCarloSquareLabel.Text = $"Площадь методом Монте-Карло: {monteCarloSquare:F4}";
        }

        // Отображает подробные результаты расчётов в сообщении
        private void ShowAnswereMessage(double realSquare, double monteCarloSquare, PointsData currentPoints)
        {
            if (!showMessageCheckBox.Checked)
                return;

            double absoluteError = Calculator.CalculateAbsoluteError(realSquare, monteCarloSquare);
            double relativeError = Calculator.CalculateRelativeError(realSquare, monteCarloSquare);
            double roundAbsoluteError = Math.Round(absoluteError, 4);
            double roundRelativeError = Math.Round(relativeError, 4);
            double maxAccuracy = 1 / (double)pointsCount;
            string message = $"""
            Площадь круга: {Calculator.CircleSuare(circle.radius):F4}
            Всего точек: {currentPoints.Points.Count}
            Количество точек попавших в круг {currentPoints.IncludedPoints.Count}
            Количество точек в большей секции: {currentPoints.CuttedPoints.Count}
            Площадь секции аналитически: {realSquare:F4}
            Площадь секции методом Монте-Карло: {monteCarloSquare:F4}
            Абсолютаня погрешность вычислений: {roundAbsoluteError}
            Относительная погрешность вычислений: {roundRelativeError}%
            Максимальная точность при заданном количестве точек: {maxAccuracy}
            """;
            MessageBox.Show(message, "Результат вычислений");
        }

        // Отображает информацию об исключении
        private void ShowException(Exception ex, string message = "")
        {
            MessageBox.Show($"{message} {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogException(ex, message);
        }

        // Устанавливает границы для трекбара параметра C
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

        #region Код ответственный за интерактивное взаимодействие на пенели управления 

        // Обрабатывает изменение координаты X центра круга
        private async void xNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            circle.circleCenter.X = (int)Math.Floor(xNumericUpDown.Value);
            SetCTrackBarBorders();
            await MonteCarloCalculate(false);
        }

        // Обрабатывает изменение координаты Y центра круга
        private async void yNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            circle.circleCenter.Y = (int)Math.Floor(yNumericUpDown.Value);
            SetCTrackBarBorders();
            await MonteCarloCalculate(false);
        }

        // Обрабатывает изменение радиуса круга
        private async void radiusSlider_Scroll(object sender, EventArgs e)
        {
            radiusLabel.Text = $"Радиус круга: {radiusTrackBar.Value}";
            circle.radius = (float)radiusTrackBar.Value;
            SetCTrackBarBorders();

            await MonteCarloCalculate(true);
        }

        // Запускает генерацию точек и расчёт по методу Монте-Карло
        private async void btnGeneratePoints_Click(object sender, EventArgs e)
        {
            await MonteCarloCalculate(true);
        }

        // Очищает сгенерированные точки
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                _pointsGenerator.ClearPoints();
                paintPanel.Invalidate();
                WriteResultOnLabels(0, 0);
                _logger.Log("Очищение точек");
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // Обрабатывает изменение количества точек для расчёта
        private async void pointsCountUpdown_ValueChanged(object sender, EventArgs e)
        {
            pointsCount = (int)pointsCountUpdown.Value;

            await MonteCarloCalculate(true);
        }

        // Обрабатывает изменение параметра C
        private async void cTrackbar_ValueChanged(object sender, EventArgs e)
        {
            circle.C = cTrackBar.Value * divisionScale;
            cLabel.Text = $"Значение C: {circle.C}";
            await MonteCarloCalculate(false);
        }

        // Обрабатывает изменение масштаба отображения
        private void scaleTrackbar_Scroll(object sender, EventArgs e)
        {
            scaleLabel.Text = $"Масштаб: {scaleTrackBar.Value}";
            _view.GridStep = scaleTrackBar.Value;

            paintPanel.Invalidate();
        }

        // Обрабатывает изменение направления сегмента (горизонтальное/вертикальное)
        private async void horizontalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (circle.direction == Direction.horizontal)
                circle.direction = Direction.vertical;
            else
                circle.direction = Direction.horizontal;

            SetCTrackBarBorders();
            await MonteCarloCalculate(false);
        }

        #endregion

        #region Код ответственный за верхнее меню

        // Открывает файл справки
        private void programHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string helpFile = Path.Combine(Application.StartupPath, "Help", "index.htm");

                // Открываем справку в браузере по умолчанию
                Process.Start(new ProcessStartInfo
                {
                    FileName = helpFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowException(ex, $"Не удалось открыть справку");
            }
        }

        // Открывает форму "О программе"
        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new AboutProgramForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // Открывает форму анализа результатов для текущих параметров
        private void analysisOfResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var circleParam = _databaseHelper.GetData(circle, pointsCount);
                var form = new AnalysisForm(circleParam);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // Открывает форму управления данными экспериментов
        private void dataManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new DataManagementForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // Закрывает приложение
        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        #endregion

        // Перерисовывает панель при изменении размера
        private void paintPanel_Resize(object sender, EventArgs e)
        {
            paintPanel.Invalidate();
        }

        // Обрабатывает закрытие формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _generationCts?.Cancel();
            _logger.Log("Приложение закрыто");
            Application.Exit();
        }

        // Обрабатывает событие отрисовки панели с графикой
        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                _view.RenderToBuffer(
                    paintPanel,
                    e,
                    circle,
                    _pointsGenerator.GetCurrentPoints()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка из-за частой переотрисовки графика.\n" +
                    "Пожалуйста, дайте время на переотрисовку графика",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Thread.Sleep(100);
                _view.RenderToBuffer(
                    paintPanel,
                    e,
                    circle,
                    _pointsGenerator.GetCurrentPoints()
                );
            }

            base.OnPaint(e);
        }
    }
}