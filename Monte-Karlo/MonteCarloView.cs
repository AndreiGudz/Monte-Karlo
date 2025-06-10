using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo
{
    public static class MonteCarloView
    {
        public static int GridStep 
        { 
            get => _gridStep;
            set
            {
                _gridStep = value;
                _step = _gridStep * 2;
            }
        }
        private static int _gridStep = 40;
        private static int _step = 80;

        private static readonly Pen _gridPen = new(Color.LightGray, 1);
        private static readonly Pen _axisPen = new(Color.Black, 2);

        private static readonly Pen _cutterPen = new(Color.Red, 4);

        private static readonly Pen _circlePen = new(Color.Red, 2);
        private static readonly Pen _squarePen = new(Color.Red, 2);

        //private static readonly Pen _excludedPointsBrush = new(Color.Aqua, 1);
        private static readonly Pen _cuttedPointsBrush = new(Color.FromArgb(174, 206, 180), 1);

        private static readonly Color _textColor = Color.Black;
        private static readonly Brush _textBrush = new SolidBrush(_textColor);
        private static readonly Font _textFont = new("Arial", 8);



        public static void RenderToBuffer(Panel panel, PaintEventArgs e, float radius, Point center, Direction direction, float C)
        {
            e.Graphics.Clear(Color.White);
            OnPaint(panel, e, radius, center, direction, C);
        }

        private static void OnPaint(Panel panel, PaintEventArgs e, float radius, Point center, Direction direction, float C)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            float centerX = panel.Size.Width / 2;
            float centerY = panel.Size.Height / 2;
            var centerScreen = new PointF(centerX, centerY);
            float squareX = centerX - radius * _step;
            float squareY = centerY - radius * _step;
            var squarePoint = new PointF(squareX, squareY);
            float coordinateX = centerX - center.X * _step;
            float coordinateY = centerY + center.Y * _step;
            var coordinate = new PointF(coordinateX, coordinateY);

            DrawPoints(g, centerScreen, _step);
            DrawGrid(panel, g, coordinate, centerScreen);
            DrawAxis(panel, g, coordinate);
            DrawCoordinateNumbers(panel, g, coordinate, centerScreen);
            DrawRectangle(g, squarePoint, _step * radius * 2);
            DrawEllipse(g, squarePoint, _step * radius * 2);
            DrawCutter(panel, g, coordinate, direction, C);
        }

        private static void DrawGrid(Panel panel, Graphics g, PointF center, PointF centerScreen)
        {
            // Вертикальные линии (сетка)
            for (float x = center.X; x < centerScreen.X + panel.Width; x += _gridStep)
            {
                g.DrawLine(_gridPen, x, 0, x, panel.Height);
                g.DrawLine(_gridPen, 2 * center.X - x, 0, 2 * center.X - x, panel.Height);
            }

            // Горизонтальные линии (сетка)
            for (float y = center.Y; y < centerScreen.Y + panel.Height; y += _gridStep)
            {
                g.DrawLine(_gridPen, 0, y, panel.Width, y);
                g.DrawLine(_gridPen, 0, 2 * center.Y - y, panel.Width, 2 * center.Y - y);
            }
        }
        private static void DrawAxis(Panel panel, Graphics g, PointF center)
        {
            g.DrawLine(_axisPen, 0, center.Y, panel.Width, center.Y);
            g.DrawLine(_axisPen, center.X, 0, center.X, panel.Height);
        }
        private static void DrawCoordinateNumbers(Panel panel, Graphics g, PointF center, PointF centerScreen)
        {
            for (float x = center.X; x < centerScreen.X + panel.Width; x += _step)
            {
                int number = (int)((x - center.X) / _step);
                if (number != 0)
                {
                    string text = number.ToString();
                    SizeF textSize = g.MeasureString(text, _textFont);
                    g.DrawString(text, _textFont, _textBrush, x - textSize.Width / 2, center.Y + 5);
                }

                if (x != center.X)
                {
                    string negativeText = (-number).ToString();
                    SizeF negativeTextSize = g.MeasureString(negativeText, _textFont);
                    g.DrawString(negativeText, _textFont, _textBrush, 2 * center.X - x - negativeTextSize.Width / 2, center.Y + 5);
                }
            }

            for (float y = center.Y; y < centerScreen.Y + panel.Height; y += _step)
            {
                int number = (int)((y - center.Y) / _step);
                if (number != 0)
                {
                    string text = (-number).ToString();
                    SizeF textSize = g.MeasureString(text, _textFont);
                    g.DrawString(text, _textFont, _textBrush, center.X + 5, y - textSize.Height / 2);
                }

                if (y != center.Y)
                {
                    string positiveText = number.ToString();
                    SizeF positiveTextSize = g.MeasureString(positiveText, _textFont);
                    g.DrawString(positiveText, _textFont, _textBrush, center.X + 5, 2 * center.Y - y - positiveTextSize.Height / 2);
                }
            }

            g.DrawString("0", _textFont, _textBrush, center.X + 5, center.Y + 5);
        }

        private static void DrawRectangle(Graphics g, PointF square, float squareSize)
        {
            g.DrawRectangle(_squarePen, square.X, square.Y, squareSize, squareSize);
        }
        private static void DrawEllipse(Graphics g, PointF square, float squareSize)
        {
            g.DrawEllipse(_circlePen, square.X, square.Y, squareSize, squareSize);
        }

        private static void DrawCutter(Panel panel, Graphics g, PointF center, Direction direction, float C)
        {
            if (direction == Direction.horizontal)
                g.DrawLine(_cutterPen, 0, center.Y + _step * -C, panel.Width, center.Y + _step * -C);
            else
                g.DrawLine(_cutterPen, center.X + _step * C, 0, center.X + _step * C, panel.Height);
        }

        private static void DrawPoints(Graphics g, PointF center, float gridStep)
        {
            foreach (var point in PointsGenerator.CuttedPoints)
            {
                g.DrawRectangle(_cuttedPointsBrush, point.X * gridStep + center.X, point.Y * gridStep + center.Y, 1, 1);
            }
        }
    }
}
