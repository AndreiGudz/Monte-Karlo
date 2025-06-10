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
            float squareX = centerX - radius * _step;
            float squareY = centerY - radius * _step;
            float coordinateX = centerX - center.X * _step;
            float coordinateY = centerY + center.Y * _step;
            PointF pointF = new PointF(coordinateX, coordinateY);

            DrawRectangle(g, squareX, squareY, _step * radius * 2);
            DrawEllipse(g, squareX, squareY, _step * radius * 2);
            DrawPoints(g, centerX, centerY, _step);
            DrawCutter(panel, g, pointF, direction, C);
            DrawGrid(panel, g, coordinateX, coordinateY);
            DrawAxis(panel, g, coordinateX, coordinateY);
            DrawCoordinateNumbers(panel, g, coordinateX, coordinateY);
        }

        private static void DrawGrid(Panel panel, Graphics g, float centerX, float centerY)
        {
            // Вертикальные линии (сетка)
            for (float x = centerX; x < panel.Width + centerX; x += _gridStep)
            {
                g.DrawLine(_gridPen, x, 0, x, panel.Height);
                g.DrawLine(_gridPen, 2 * centerX - x, 0, 2 * centerX - x, panel.Height);
            }

            // Горизонтальные линии (сетка)
            for (float y = centerY; y < panel.Height + centerY; y += _gridStep)
            {
                g.DrawLine(_gridPen, 0, y, panel.Width, y);
                g.DrawLine(_gridPen, 0, 2 * centerY - y, panel.Width, 2 * centerY - y);
            }
        }
        private static void DrawAxis(Panel panel, Graphics g, float centerX, float centerY)
        {
            g.DrawLine(_axisPen, 0, centerY, panel.Width, centerY);
            g.DrawLine(_axisPen, centerX, 0, centerX, panel.Height);
        }
        private static void DrawCoordinateNumbers(Panel panel, Graphics g, float centerX, float centerY)
        {
            for (float x = centerX; x < panel.Width + centerX; x += _step)
            {
                int number = (int)((x - centerX) / _step);
                if (number != 0)
                {
                    string text = number.ToString();
                    SizeF textSize = g.MeasureString(text, _textFont);
                    g.DrawString(text, _textFont, _textBrush, x - textSize.Width / 2, centerY + 5);
                }

                if (x != centerX)
                {
                    string negativeText = (-number).ToString();
                    SizeF negativeTextSize = g.MeasureString(negativeText, _textFont);
                    g.DrawString(negativeText, _textFont, _textBrush, 2 * centerX - x - negativeTextSize.Width / 2, centerY + 5);
                }
            }

            for (float y = centerY; y < panel.Height + centerY; y += _step)
            {
                int number = (int)((y - centerY) / _step);
                if (number != 0)
                {
                    string text = (-number).ToString();
                    SizeF textSize = g.MeasureString(text, _textFont);
                    g.DrawString(text, _textFont, _textBrush, centerX + 5, y - textSize.Height / 2);
                }

                if (y != centerY)
                {
                    string positiveText = number.ToString();
                    SizeF positiveTextSize = g.MeasureString(positiveText, _textFont);
                    g.DrawString(positiveText, _textFont, _textBrush, centerX + 5, 2 * centerY - y - positiveTextSize.Height / 2);
                }
            }

            g.DrawString("0", _textFont, _textBrush, centerX + 5, centerY + 5);
        }

        private static void DrawRectangle(Graphics g, float squareX, float squareY, float squareSize)
        {
            g.DrawRectangle(_squarePen, squareX, squareY, squareSize, squareSize);
        }
        private static void DrawEllipse(Graphics g, float squareX, float squareY, float squareSize)
        {
            g.DrawEllipse(_circlePen, squareX, squareY, squareSize, squareSize);
        }

        private static void DrawCutter(Panel panel, Graphics g, PointF center, Direction direction, float C)
        {
            if (direction == Direction.horizontal)
                g.DrawLine(_cutterPen, 0, center.Y + _step * -C, panel.Width, center.Y + _step * -C);
            else
                g.DrawLine(_cutterPen, center.X + _step * C, 0, center.X + _step * C, panel.Height);
        }

        private static void DrawPoints(Graphics g, float startX, float startY, float gridStep)
        {
/*            foreach (var point in MonteCarloCalculator.ExcludedPoints)
            {
                g.DrawRectangle(_excludedPointsBrush, point.X * gridStep + startX, point.Y * gridStep + startY, 1, 1);
            }*/

            foreach (var point in PointsGenerator.CuttedPoints)
            {
                g.DrawRectangle(_cuttedPointsBrush, point.X * gridStep + startX, point.Y * gridStep + startY, 1, 1);
            }
        }
    }
}
