using Monte_Karlo.Calculators;
using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AnalysisView
{
    // Цвета элементов
    private static readonly Color _analyticalColor = Color.Blue;
    private static readonly Color _pointsColor = Color.Green;
    private static readonly Color _meanColor = Color.Red;
    private static readonly Color _modeColor = Color.Purple;
    private static readonly Color _minMaxColor = Color.Orange;
    private static readonly Color _backgroundColor = Color.White;
    private static readonly Color _gridColor = Color.LightGray;
    private static readonly Padding _padding = new Padding(50, 20, 70, 40);
    private static readonly double _percentYPadding = 0.1;
    private static readonly System.Drawing.Font _textFont = SystemFonts.DefaultFont;
    private static readonly Brush _textBrush = Brushes.Black;

    public void RenderAnalysis(Panel panel, PaintEventArgs e, CircleParams circleParams)
    {
        if (circleParams == null || circleParams.Results == null || circleParams.Results.Count == 0)
            return;

        var g = e.Graphics;
        g.Clear(_backgroundColor);
        OnPaint(panel, g, circleParams);
    }

    private void OnPaint(Panel panel, Graphics g, CircleParams circleParams)
    {
        List<double> mcResults = circleParams.Results.Select(r => r.MonteCarloResult).ToList();
        double analyticalValue = circleParams.AnalyticalResult;

        double mean = mcResults.Average();
        double mode = StatisticCalculator.CalculateMode(mcResults);
        double min = mcResults.Min();
        double max = mcResults.Max();

        Rectangle plotArea = new Rectangle(_padding.Left, _padding.Top, panel.Width - _padding.Right, panel.Height - _padding.Bottom);

        double yMin = Math.Min(analyticalValue, min);
        double yMax = Math.Max(analyticalValue, max);
        double yRange = yMax - yMin;
        yMin -= yRange * _percentYPadding;
        yMax += yRange * _percentYPadding;
        yRange = yMax - yMin;

        DrawGrid(g, plotArea, mcResults.Count, yMin, yMax);

        DrawAnalyticalLine(g, plotArea, analyticalValue, yMin, yRange);
        DrawMonteCarloPoints(g, plotArea, mcResults, yMin, yRange);
        DrawMeanLine(g, plotArea, mean, yMin, yRange);
        DrawModeLine(g, plotArea, mode, yMin, yRange);
        DrawMinMaxLines(g, plotArea, min, max, yMin, yRange);
        DrawLegend(g, plotArea, mode);
    }

    private void DrawGrid(Graphics g, Rectangle plotArea, int pointsCount, double yMin, double yMax)
    {
        Pen girdPen = new Pen(_gridColor);

        g.DrawRectangle(girdPen, plotArea);

        // Вертикальные линии (каждые 10% экспериментов)
        int step = Math.Max(1, pointsCount / 10);
        for (int i = 0; i <= pointsCount; i += step)
        {
            float x = plotArea.Left + plotArea.Width * i / pointsCount;
            g.DrawLine(girdPen, x, plotArea.Top, x, plotArea.Bottom);

            // Подписи номеров экспериментов
            string text = i.ToString();
            SizeF textSize = g.MeasureString(text, _textFont);
            float textX = x - textSize.Width / 2;
            float textY = plotArea.Bottom - textSize.Height;

            // особое расположение для 0
            if (i == 0)
                textX += textSize.Width;

            g.DrawString(text, _textFont, _textBrush, textX, textY);
        }

        // Горизонтальные линии сетки (5 линий)
        for (int i = 0; i <= 5; i++)
        {
            float y = plotArea.Top + plotArea.Height * i / 5;
            g.DrawLine(girdPen, plotArea.Left, y, plotArea.Right, y);

            // Подписи значений
            double yRange = yMax - yMin;
            double value = yMax - yRange * i / 5;
            string text = value.ToString("F2");
            SizeF textSize = g.MeasureString(text, _textFont);
            float textX = plotArea.Left - textSize.Width;
            float textY = y - textSize.Height / 2;
            
            g.DrawString(text, _textFont, _textBrush, textX, textY);
        }

    }

    private void DrawAnalyticalLine(Graphics g, Rectangle area, double value, double yMin, double yRange)
    {
        float y = area.Bottom - (float)((value - yMin) / yRange * area.Height);
        g.DrawLine(new Pen(_analyticalColor, 2), area.Left, y, area.Right, y);
    }

    private void DrawMonteCarloPoints(Graphics g, Rectangle area, List<double> results, double yMin, double yRange)
    {
        for (int i = 0; i < results.Count; i++)
        {
            try
            {
                float x = area.Left + area.Width * i / (results.Count - 1);
                float y = area.Bottom - (float)((results[i] - yMin) / yRange * area.Height);
                g.FillEllipse(new SolidBrush(_pointsColor), x - 2, y - 2, 4, 4);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Слишком мало данных измерений");
            }
        }
    }

    private void DrawMeanLine(Graphics g, Rectangle area, double value, double yMin, double yRange)
    {
        float y = area.Bottom - (float)((value - yMin) / yRange * area.Height);
        g.DrawLine(new Pen(_meanColor, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash },
                  area.Left, y, area.Right, y);
    }

    private void DrawModeLine(Graphics g, Rectangle area, double value, double yMin, double yRange)
    {
        float y = area.Bottom - (float)((value - yMin) / yRange * area.Height);
        g.DrawLine(new Pen(_modeColor, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot },
                  area.Left, y, area.Right, y);
    }

    private void DrawMinMaxLines(Graphics g, Rectangle area, double min, double max, double yMin, double yRange)
    {
        float yMinPos = area.Bottom - (float)((min - yMin) / yRange * area.Height);
        float yMaxPos = area.Bottom - (float)((max - yMin) / yRange * area.Height);

        g.DrawLine(new Pen(_minMaxColor, 1), area.Left, yMinPos, area.Right, yMinPos);
        g.DrawLine(new Pen(_minMaxColor, 1), area.Left, yMaxPos, area.Right, yMaxPos);
    }

    private void DrawLegend(Graphics g, Rectangle area, double mode)
    {
        SizeF textSize = g.MeasureString("Аналитическое решение", _textFont);
        float boxWidth = 20;
        float startX = area.Width - textSize.Width - boxWidth - 5;
        float startY = area.Top;
        float itemHeight = textSize.Height;

        DrawLegendItem(g, "Аналитическое решение", _analyticalColor, startX, startY, boxWidth, itemHeight);
        DrawLegendItem(g, "Точки Монте-Карло", _pointsColor, startX, startY + itemHeight, boxWidth, itemHeight);
        DrawLegendItem(g, "Среднее значение", _meanColor, startX, startY + itemHeight * 2, boxWidth, itemHeight);
        DrawLegendItem(g, "Мода", _modeColor, startX, startY + itemHeight * 3, boxWidth, itemHeight);
        DrawLegendItem(g, "Минимум/Максимум", _minMaxColor, startX, startY + itemHeight * 4, boxWidth, itemHeight);
    }

    private void DrawLegendItem(Graphics g, string text, Color color, float x, float y, float boxWidth, float boxHeight)
    {
        SizeF textSize = g.MeasureString("Аналитическое решение", _textFont);
        g.FillRectangle(new SolidBrush(color), x, y + 1, boxWidth, boxHeight - 2);
        g.DrawRectangle(Pens.Black, x, y + 1, boxWidth, boxHeight - 2);
        g.DrawString(text, _textFont, _textBrush, x + boxWidth + 5, y);
    }
}