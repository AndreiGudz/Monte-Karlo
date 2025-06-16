using Microsoft.EntityFrameworkCore;
using Monte_Karlo.Calculators;
using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Monte_Karlo
{
    public partial class AnalysisForm : Form
    {
        private List<SimulationResult> _results = new List<SimulationResult>();
        private CircleParams _currentParams;

        public AnalysisForm()
        {
            InitializeComponent();
        }

        public AnalysisForm(CircleParams circleParams) : this()
        {
            if (circleParams is not null)
            {
                _currentParams = circleParams;
                _results = circleParams.Results;
            }
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            CalculateStatistics();
        }

        private void SetupDataGridView()
        {
            // Очищаем и настраиваем DataGridView
            dataGridViewResults.AutoGenerateColumns = false;
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewResults.EnableHeadersVisualStyles = false;
            dataGridViewResults.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dataGridViewResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Добавляем колонки с настройками
            AddColumn("PointsInCircle", "Points in Circle", "PointsInCircle", false, "N0");
            AddColumn("PointsInSegment", "Points in Segment", "PointsInSegment", false, "N0");
            AddColumn("MonteCarloResult", "Monte-Carlo Result", "MonteCarloResult", true, "F4");
            AddColumn("AnalyticalResult", "Analytical Result", "AnalyticalResult", true, "F4",
                     _currentParams?.AnalyticalResult.ToString("F4") ?? "N/A");
            AddColumn("ErrorPct", "Error (%)", "ErrorPct", true, "F2");

            if (_currentParams != null && _currentParams.Results.Any())
            {
                // Создаем список с дополнительным полем Error
                var displayResults = _currentParams.Results
                    .OrderByDescending(r => r.Id)
                    .Select(r => new
                    {
                        r.PointsInCircle,
                        r.PointsInSegment,
                        r.MonteCarloResult,
                        AnalyticalResult = _currentParams.AnalyticalResult,
                        ErrorPct = Calculator.CalculateRelativeError(_currentParams.AnalyticalResult, r.MonteCarloResult).ToString(),
                    })
                    .ToList();

                var bindingSource = new BindingSource() { DataSource = displayResults};
                dataGridViewResults.DataSource = bindingSource;

                dataGridViewResults.ColumnHeaderMouseClick += DataGridViewResults_ColumnHeaderMouseClick;
                // Настраиваем цветовое форматирование для колонки с ошибкой
                dataGridViewResults.CellFormatting += (sender, e) =>
                {
                    if (e.ColumnIndex == dataGridViewResults.Columns["ErrorPct"].Index && e.Value != null)
                    {
                        double error = Convert.ToDouble(e.Value);
                        e.CellStyle.ForeColor = error switch
                        {
                            > 10 => Color.Red,
                            > 5 => Color.Orange,
                            _ => Color.Green
                        };
                    }
                };
            }
            else
            {
                dataGridViewResults.DataSource = null;
                dataGridViewResults.Columns["AnalyticalResult"].DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        // Вспомогательный метод для добавления колонок
        private void AddColumn(string name, string header, string dataPropertyName,
                              bool isReadOnly, string format, object defaultValue = null)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataPropertyName,
                ReadOnly = isReadOnly,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = format,
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                SortMode = DataGridViewColumnSortMode.Programmatic
            };

            if (defaultValue != null)
            {
                col.DefaultCellStyle.NullValue = defaultValue;
            }

            dataGridViewResults.Columns.Add(col);
        }

        private void DataGridViewResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dataGridViewResults.Columns[e.ColumnIndex];
            ListSortDirection direction;

            // Определяем направление сортировки
            if (column.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Сортируем данные
            SortData(column.Name, direction);

            // Обновляем иконку сортировки
            dataGridViewResults.Columns.Cast<DataGridViewColumn>()
                .ToList()
                .ForEach(c => c.HeaderCell.SortGlyphDirection = SortOrder.None);

            column.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
                SortOrder.Ascending :
                SortOrder.Descending;
        }

        private void SortData(string columnName, ListSortDirection direction)
        {
            if (dataGridViewResults.DataSource is BindingSource bindingSource)
            {
                var data = bindingSource.List.Cast<dynamic>().ToList();

                switch (columnName)
                {
                    case "PointsInCircle":
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.PointsInCircle).ToList() :
                            data.OrderByDescending(x => x.PointsInCircle).ToList();
                        break;
                    case "PointsInSegment":
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.PointsInSegment).ToList() :
                            data.OrderByDescending(x => x.PointsInSegment).ToList();
                        break;
                    case "MonteCarloResult":
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.MonteCarloResult).ToList() :
                            data.OrderByDescending(x => x.MonteCarloResult).ToList();
                        break;
                    case "AnalyticalResult":
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.AnalyticalResult).ToList() :
                            data.OrderByDescending(x => x.AnalyticalResult).ToList();
                        break;
                    case "ErrorPct":
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.ErrorPct).ToList() :
                            data.OrderByDescending(x => x.ErrorPct).ToList();
                        break;
                    default:
                        bindingSource.DataSource = direction == ListSortDirection.Ascending ?
                            data.OrderBy(x => x.Id).ToList() :
                            data.OrderByDescending(x => x.Id).ToList();
                        break;
                }
            }
        }

        private void CalculateStatistics()
        {
            if (_results == null || _results.Count == 0) 
                return;

            lblAnalisicResult.Text = _currentParams.AnalyticalResult.ToString("F4");
            var mcResults = _results.Select(r => r.MonteCarloResult).ToList();

            // Central tendency
            lblMean.Text = mcResults.Average().ToString("F4");
            lblMedian.Text = StatisticCalculator.CalculateMedian(mcResults).ToString("F4");
            lblMode.Text = StatisticCalculator.CalculateMode(mcResults).ToString("F4");

            // Variability
            double variance = StatisticCalculator.CalculateVariance(mcResults);
            lblVariance.Text = variance.ToString("F4");
            lblStdDev.Text = StatisticCalculator.CalculateStandardDeviation(variance).ToString("F4");
            lblRange.Text = StatisticCalculator.CalculateRange(mcResults).ToString("F4");
        }

        
    }
}
