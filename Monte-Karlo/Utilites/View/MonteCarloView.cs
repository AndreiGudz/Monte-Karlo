// Класс для визуализации графика Монте-Карло на основной форме
// Отрисовывает фигуры и точки в большем сегменте на панели
using Monte_Karlo.Models;

namespace Monte_Karlo.Utilites.View
{
    public class MonteCarloView
    {
        // Шаг сетки (в пикселях)
        public int GridStep
        {
            get => _gridStep;
            set
            {
                _gridStep = value;
                _step = _gridStep * 2;
            }
        }
        private int _gridStep = 40;
        private int _step = 80;

        // Цвета и кисти для отрисовки
        private static readonly Color _backgroundColor = Color.White;
        private static readonly Pen _gridPen = new(Color.LightGray, 1);
        private static readonly Pen _axisPen = new(Color.Black, 2);
        private static readonly Pen _cutterPen = new(Color.Red, 4);
        private static readonly Pen _circlePen = new(Color.Red, 2);
        private static readonly Pen _squarePen = new(Color.Red, 2);
        private static readonly Pen _cuttedPointsBrush = new(Color.FromArgb(174, 206, 180), 1);
        private static readonly Color _textColor = Color.Black;
        private static readonly Brush _textBrush = new SolidBrush(_textColor);
        private static readonly Font _textFont = new("Arial", 8);

        // Основной метод рендеринга на буфер панели
        public void RenderToBuffer(Panel panel, PaintEventArgs e, Circle circle, PointsData pointsData)
        {
            e.Graphics.Clear(_backgroundColor);
            OnPaint(panel, e, circle.radius, circle.circleCenter, circle.direction, circle.C, pointsData);
        }

        // Обрабатывает событие отрисовки, координирует вызов всех методов рисования
        private void OnPaint(Panel panel, PaintEventArgs e, float radius, Point circleCenter, Direction direction, float C, PointsData pointsData)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // Вычисляем координаты центра и углов
            float centerX = panel.Size.Width / 2;
            float centerY = panel.Size.Height / 2;
            var centerScreen = new PointF(centerX, centerY);
            float squareX = centerX - radius * _step;
            float squareY = centerY - radius * _step;
            var squarePoint = new PointF(squareX, squareY);
            float originX = centerX - circleCenter.X * _step;
            float originY = centerY + circleCenter.Y * _step;
            var origin = new PointF(originX, originY);

            // Последовательность отрисовки элементов
            DrawPoints(g, centerScreen, _step, pointsData);
            DrawGrid(panel, g, origin);
            DrawAxis(panel, g, origin);
            DrawCoordinateNumbers(panel, g, origin);
            DrawRectangle(g, squarePoint, _step * radius * 2);
            DrawEllipse(g, squarePoint, _step * radius * 2);
            DrawCutter(panel, g, origin, direction, C);
        }

        // Рисует координатную сетку
        private void DrawGrid(Panel panel, Graphics g, PointF origin)
        {
            // Вертикальные линии
            for (float x = origin.X; x >= 0; x -= _gridStep)
            {
                g.DrawLine(_gridPen, x, 0, x, panel.Height);
            }
            for (float x = origin.X; x <= panel.Width; x += _gridStep)
            {
                g.DrawLine(_gridPen, x, 0, x, panel.Height);
            }

            // Горизонтальные линии
            for (float y = origin.Y; y >= 0; y -= _gridStep)
            {
                g.DrawLine(_gridPen, 0, y, panel.Width, y);
            }
            for (float y = origin.Y; y <= panel.Height; y += _gridStep)
            {
                g.DrawLine(_gridPen, 0, y, panel.Width, y);
            }
        }

        // Рисует оси координат
        private void DrawAxis(Panel panel, Graphics g, PointF center)
        {
            g.DrawLine(_axisPen, 0, center.Y, panel.Width, center.Y);
            g.DrawLine(_axisPen, center.X, 0, center.X, panel.Height);
        }

        // Рисует числовые подписи на осях координат
        private void DrawCoordinateNumbers(Panel panel, Graphics g, PointF origin)
        {
            // Числа на оси X (влево)
            for (float x = origin.X; x >= 0; x -= _step)
            {
                int digit = (int)Math.Round((x - origin.X) / _step);
                if (digit == 0)
                    continue;

                string text = digit.ToString();
                SizeF textSize = g.MeasureString(text, _textFont);
                float textX = x - textSize.Width / 2;
                float textY = origin.Y + 5;

                if (TextInPanel(panel, textSize, textX, textY))
                {
                    g.DrawString(text, _textFont, _textBrush, textX, textY);
                }
            }

            // Числа на оси X (вправо)
            for (float x = origin.X; x <= panel.Width; x += _step)
            {
                int digit = (int)Math.Round((x - origin.X) / _step);
                if (digit == 0)
                    continue;

                string text = digit.ToString();
                SizeF textSize = g.MeasureString(text, _textFont);
                float textX = x - textSize.Width / 2;
                float textY = origin.Y + 5;

                if (TextInPanel(panel, textSize, textX, textY))
                {
                    g.DrawString(text, _textFont, _textBrush, textX, textY);
                }
            }


            // Числа на оси Y (вверх)
            for (float y = origin.Y; y >= 0; y -= _step)
            {
                int digit = -(int)Math.Round((y - origin.Y) / _step);
                if (digit == 0)
                    continue;

                string text = digit.ToString();
                SizeF textSize = g.MeasureString(text, _textFont);
                float textX = origin.X + 5;
                float textY = y - textSize.Height / 2;

                if (TextInPanel(panel, textSize, textX, textY))
                {
                    g.DrawString(text, _textFont, _textBrush, textX, textY);
                }
            }


            // Числа на оси Y (вниз)
            for (float y = origin.Y; y <= panel.Height; y += _step)
            {
                int digit = -(int)Math.Round((y - origin.Y) / _step);
                if (digit == 0)
                    continue;

                string text = digit.ToString();
                SizeF textSize = g.MeasureString(text, _textFont);
                float textX = origin.X + 5;
                float textY = y - textSize.Height / 2;

                if (TextInPanel(panel, textSize, textX, textY))
                {
                    g.DrawString(text, _textFont, _textBrush, textX, textY);
                }
            }

            // Рисуем ноль в начале координат
            g.DrawString("0", _textFont, _textBrush, origin.X + 5, origin.Y + 5);
        }

        // Проверяет, помещается ли текст в границы панели
        private bool TextInPanel(Panel panel, SizeF textSize, float textX = 0, float textY = 0)
        {
            bool xIn = textX >= 0 && textX + textSize.Width <= panel.Width;
            bool yIn = textY >= 0 && textY + textSize.Height <= panel.Height;
            return xIn && yIn;
        }

        // Рисует ограничивающий квадрат
        private void DrawRectangle(Graphics g, PointF square, float squareSize)
        {
            g.DrawRectangle(_squarePen, square.X, square.Y, squareSize, squareSize);
        }

        // Рисует окружность
        private void DrawEllipse(Graphics g, PointF square, float squareSize)
        {
            g.DrawEllipse(_circlePen, square.X, square.Y, squareSize, squareSize);
        }

        // Рисует линию разреза (сектор)
        private void DrawCutter(Panel panel, Graphics g, PointF center, Direction direction, float C)
        {
            if (direction == Direction.horizontal)
                g.DrawLine(_cutterPen, 0, center.Y + _step * -C, panel.Width, center.Y + _step * -C);
            else
                g.DrawLine(_cutterPen, center.X + _step * C, 0, center.X + _step * C, panel.Height);
        }

        // Рисует точки Монте-Карло (с ограничением количества для производительности)
        private void DrawPoints(Graphics g, PointF center, float gridStep, PointsData pointsData)
        {
            if (pointsData.CuttedPoints.Count == 0)
                return;

            // Ограничение количества отображаемых точек
            const int ViewPointsLimit = 100_000;
            int pointsToDraw = Math.Min(pointsData.CuttedPoints.Count, ViewPointsLimit);
            var rectangles = new RectangleF[pointsToDraw];

            // Преобразуем координаты точек в экранные координаты
            for (int i = 0; i < pointsToDraw; i++)
            {
                var point = pointsData.CuttedPoints[i];
                float screenX = center.X + point.X * gridStep;
                float screenY = center.Y - point.Y * gridStep;
                rectangles[i] = new RectangleF(screenX, screenY, 1, 1);
            }

            // Массовая отрисовка точек
            g.DrawRectangles(_cuttedPointsBrush, rectangles);
        }
    }
}