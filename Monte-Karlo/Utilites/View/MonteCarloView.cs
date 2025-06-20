using Monte_Karlo.Models;
using Monte_Karlo.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.Utilites.View
{
    public class MonteCarloView
    {
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

        private static readonly Color _backgroundColor = Color.White;
        private static readonly Pen _gridPen = new(Color.LightGray, 1);
        private static readonly Pen _axisPen = new(Color.Black, 2);

        private static readonly Pen _cutterPen = new(Color.Red, 4);

        private static readonly Pen _circlePen = new(Color.Red, 2);
        private static readonly Pen _squarePen = new(Color.Red, 2);

        private static readonly Pen _excludedPointsBrush = new(Color.Gray, 1);
        private static readonly Pen _includedPointsBrush = new(Color.Yellow, 1);
        private static readonly Pen _cuttedPointsBrush = new(Color.FromArgb(174, 206, 180), 1);

        private static readonly Color _textColor = Color.Black;
        private static readonly Brush _textBrush = new SolidBrush(_textColor);
        private static readonly Font _textFont = new("Arial", 8);



        public void RenderToBuffer(Panel panel, PaintEventArgs e, Circle circle, PointsData pointsData)
        {
            e.Graphics.Clear(_backgroundColor);
            OnPaint(panel, e, circle.radius, circle.circleCenter, circle.direction, circle.C, pointsData);
        }

        private void OnPaint(Panel panel, PaintEventArgs e, float radius, Point circleCenter, Direction direction, float C, PointsData pointsData)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            float centerX = panel.Size.Width / 2;
            float centerY = panel.Size.Height / 2;
            var centerScreen = new PointF(centerX, centerY);
            float squareX = centerX - radius * _step;
            float squareY = centerY - radius * _step;
            var squarePoint = new PointF(squareX, squareY);
            float originX = centerX - circleCenter.X * _step;
            float originY = centerY + circleCenter.Y * _step;
            var origin = new PointF(originX, originY);

            DrawPoints(g, centerScreen, _step, pointsData);
            DrawGrid(panel, g, origin);
            DrawAxis(panel, g, origin);
            DrawCoordinateNumbers(panel, g, origin);
            DrawRectangle(g, squarePoint, _step * radius * 2);
            DrawEllipse(g, squarePoint, _step * radius * 2);
            DrawCutter(panel, g, origin, direction, C);
        }

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

        private void DrawAxis(Panel panel, Graphics g, PointF center)
        {
            g.DrawLine(_axisPen, 0, center.Y, panel.Width, center.Y);
            g.DrawLine(_axisPen, center.X, 0, center.X, panel.Height);
        }
        private void DrawCoordinateNumbers(Panel panel, Graphics g, PointF origin)
        {
            // Числа на оси X
            // влево
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

            // вправо
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


            // Числа на оси Y
            // вверх
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


            // вниз
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

            g.DrawString("0", _textFont, _textBrush, origin.X + 5, origin.Y + 5);
        }

        private bool TextInPanel(Panel panel, SizeF textSize, float textX = 0, float textY = 0)
        {
            bool xIn = textX >= 0 && textX + textSize.Width <= panel.Width;
            bool yIn = textY >= 0 && textY + textSize.Height <= panel.Height;
            return xIn && yIn;
        }

        private void DrawRectangle(Graphics g, PointF square, float squareSize)
        {
            g.DrawRectangle(_squarePen, square.X, square.Y, squareSize, squareSize);
        }
        private void DrawEllipse(Graphics g, PointF square, float squareSize)
        {
            g.DrawEllipse(_circlePen, square.X, square.Y, squareSize, squareSize);
        }

        private void DrawCutter(Panel panel, Graphics g, PointF center, Direction direction, float C)
        {
            if (direction == Direction.horizontal)
                g.DrawLine(_cutterPen, 0, center.Y + _step * -C, panel.Width, center.Y + _step * -C);
            else
                g.DrawLine(_cutterPen, center.X + _step * C, 0, center.X + _step * C, panel.Height);
        }

        private void DrawPoints(Graphics g, PointF center, float gridStep, PointsData pointsData)
        {
/*            foreach (var point in pointsData.ExcludedPoints)
            {
                g.DrawRectangle(_excludedPointsBrush, point.X * gridStep + center.X, center.Y - point.Y * gridStep, 1, 1);
            }
            foreach (var point in pointsData.IncludedPoints)
            {
                g.DrawRectangle(_includedPointsBrush, point.X * gridStep + center.X, center.Y - point.Y * gridStep, 1, 1);
            }*/
            foreach (var point in pointsData.CuttedPoints)
            {
                float screenX = center.X + point.X * gridStep;
                float screenY = center.Y - point.Y * gridStep;
                g.DrawRectangle(_cuttedPointsBrush, screenX, screenY, 1, 1);
            }
        }
    }
}
