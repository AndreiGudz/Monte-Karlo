
namespace Monte_Karlo
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
            tabControl1 = new TabControl();
            tabPageStats = new TabPage();
            splitContainer2 = new SplitContainer();
            groupBoxStats = new GroupBox();
            lblRange = new Label();
            lblMaximum = new Label();
            lblMinimum = new Label();
            lblStdDev = new Label();
            lblVariance = new Label();
            lblMode = new Label();
            lblMedian = new Label();
            lblMean = new Label();
            lblAnalisicResult = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridViewResults = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            tabPageGraph = new TabPage();
            paintPanel = new Panel();
            tabControl1.SuspendLayout();
            tabPageStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            tabPageGraph.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageStats);
            tabControl1.Controls.Add(tabPageGraph);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1371, 900);
            tabControl1.TabIndex = 0;
            // 
            // tabPageStats
            // 
            tabPageStats.Controls.Add(splitContainer2);
            tabPageStats.Location = new Point(4, 39);
            tabPageStats.Margin = new Padding(5, 6, 5, 6);
            tabPageStats.Name = "tabPageStats";
            tabPageStats.Padding = new Padding(5, 6, 5, 6);
            tabPageStats.Size = new Size(1363, 857);
            tabPageStats.TabIndex = 0;
            tabPageStats.Text = "Статистический анализ";
            tabPageStats.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(5, 6);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBoxStats);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridViewResults);
            splitContainer2.Size = new Size(1353, 845);
            splitContainer2.SplitterDistance = 494;
            splitContainer2.SplitterWidth = 8;
            splitContainer2.TabIndex = 0;
            // 
            // groupBoxStats
            // 
            groupBoxStats.Controls.Add(lblRange);
            groupBoxStats.Controls.Add(lblMaximum);
            groupBoxStats.Controls.Add(lblMinimum);
            groupBoxStats.Controls.Add(lblStdDev);
            groupBoxStats.Controls.Add(lblVariance);
            groupBoxStats.Controls.Add(lblMode);
            groupBoxStats.Controls.Add(lblMedian);
            groupBoxStats.Controls.Add(lblMean);
            groupBoxStats.Controls.Add(lblAnalisicResult);
            groupBoxStats.Controls.Add(label9);
            groupBoxStats.Controls.Add(label8);
            groupBoxStats.Controls.Add(label7);
            groupBoxStats.Controls.Add(label6);
            groupBoxStats.Controls.Add(label5);
            groupBoxStats.Controls.Add(label4);
            groupBoxStats.Controls.Add(label3);
            groupBoxStats.Controls.Add(label2);
            groupBoxStats.Controls.Add(label1);
            groupBoxStats.Dock = DockStyle.Fill;
            groupBoxStats.Location = new Point(0, 0);
            groupBoxStats.Margin = new Padding(5, 6, 5, 6);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Padding = new Padding(5, 6, 5, 6);
            groupBoxStats.Size = new Size(494, 845);
            groupBoxStats.TabIndex = 1;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "Статистический анализ измерений";
            // 
            // lblRange
            // 
            lblRange.AutoSize = true;
            lblRange.Location = new Point(301, 540);
            lblRange.Margin = new Padding(5, 0, 5, 0);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(21, 30);
            lblRange.TabIndex = 11;
            lblRange.Text = "-";
            // 
            // lblMaximum
            // 
            lblMaximum.AutoSize = true;
            lblMaximum.Location = new Point(301, 480);
            lblMaximum.Margin = new Padding(5, 0, 5, 0);
            lblMaximum.Name = "lblMaximum";
            lblMaximum.Size = new Size(21, 30);
            lblMaximum.TabIndex = 17;
            lblMaximum.Text = "-";
            // 
            // lblMinimum
            // 
            lblMinimum.AutoSize = true;
            lblMinimum.Location = new Point(301, 420);
            lblMinimum.Margin = new Padding(5, 0, 5, 0);
            lblMinimum.Name = "lblMinimum";
            lblMinimum.Size = new Size(21, 30);
            lblMinimum.TabIndex = 16;
            lblMinimum.Text = "-";
            // 
            // lblStdDev
            // 
            lblStdDev.AutoSize = true;
            lblStdDev.Location = new Point(301, 360);
            lblStdDev.Margin = new Padding(5, 0, 5, 0);
            lblStdDev.Name = "lblStdDev";
            lblStdDev.Size = new Size(21, 30);
            lblStdDev.TabIndex = 10;
            lblStdDev.Text = "-";
            // 
            // lblVariance
            // 
            lblVariance.AutoSize = true;
            lblVariance.Location = new Point(301, 300);
            lblVariance.Margin = new Padding(5, 0, 5, 0);
            lblVariance.Name = "lblVariance";
            lblVariance.Size = new Size(21, 30);
            lblVariance.TabIndex = 9;
            lblVariance.Text = "-";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(301, 240);
            lblMode.Margin = new Padding(5, 0, 5, 0);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(21, 30);
            lblMode.TabIndex = 8;
            lblMode.Text = "-";
            // 
            // lblMedian
            // 
            lblMedian.AutoSize = true;
            lblMedian.Location = new Point(301, 180);
            lblMedian.Margin = new Padding(5, 0, 5, 0);
            lblMedian.Name = "lblMedian";
            lblMedian.Size = new Size(21, 30);
            lblMedian.TabIndex = 7;
            lblMedian.Text = "-";
            // 
            // lblMean
            // 
            lblMean.AutoSize = true;
            lblMean.Location = new Point(301, 120);
            lblMean.Margin = new Padding(5, 0, 5, 0);
            lblMean.Name = "lblMean";
            lblMean.Size = new Size(21, 30);
            lblMean.TabIndex = 6;
            lblMean.Text = "-";
            // 
            // lblAnalisicResult
            // 
            lblAnalisicResult.AutoSize = true;
            lblAnalisicResult.Location = new Point(301, 60);
            lblAnalisicResult.Margin = new Padding(5, 0, 5, 0);
            lblAnalisicResult.Name = "lblAnalisicResult";
            lblAnalisicResult.Size = new Size(21, 30);
            lblAnalisicResult.TabIndex = 13;
            lblAnalisicResult.Text = "-";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(30, 540);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(86, 30);
            label9.TabIndex = 5;
            label9.Text = "Размах:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 480);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(120, 30);
            label8.TabIndex = 15;
            label8.Text = "Максимум:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 420);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(113, 30);
            label7.TabIndex = 14;
            label7.Text = "Минимум:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 360);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(259, 30);
            label6.TabIndex = 4;
            label6.Text = "Стандартное отклонение:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 300);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 30);
            label5.TabIndex = 3;
            label5.Text = "Дисперсия:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 240);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 30);
            label4.TabIndex = 2;
            label4.Text = "Мода:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 180);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 1;
            label3.Text = "Медиана:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 30);
            label2.TabIndex = 0;
            label2.Text = "Среднее:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 60);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 12;
            label1.Text = "Аналитический результат:";
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewResults.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewResults.Dock = DockStyle.Fill;
            dataGridViewResults.EnableHeadersVisualStyles = false;
            dataGridViewResults.Location = new Point(0, 0);
            dataGridViewResults.Margin = new Padding(5, 6, 5, 6);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.RowHeadersWidth = 72;
            dataGridViewResults.RowTemplate.Height = 25;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(851, 845);
            dataGridViewResults.TabIndex = 2;
            dataGridViewResults.CellFormatting += DataGridViewResults_CellFormatting;
            dataGridViewResults.ColumnHeaderMouseClick += DataGridViewResults_ColumnHeaderMouseClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 9;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 9;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.MinimumWidth = 9;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // tabPageGraph
            // 
            tabPageGraph.Controls.Add(paintPanel);
            tabPageGraph.Location = new Point(4, 39);
            tabPageGraph.Margin = new Padding(5, 6, 5, 6);
            tabPageGraph.Name = "tabPageGraph";
            tabPageGraph.Padding = new Padding(5, 6, 5, 6);
            tabPageGraph.Size = new Size(1363, 857);
            tabPageGraph.TabIndex = 1;
            tabPageGraph.Text = "Графический анализ";
            tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // paintPanel
            // 
            paintPanel.BackColor = Color.White;
            paintPanel.Dock = DockStyle.Fill;
            paintPanel.Location = new Point(5, 6);
            paintPanel.Margin = new Padding(5, 6, 5, 6);
            paintPanel.Name = "paintPanel";
            paintPanel.Size = new Size(1353, 845);
            paintPanel.TabIndex = 3;
            paintPanel.Paint += paintPanel_Paint;
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "AnalysisForm";
            Text = "Анализ результатов измерений";
            Load += AnalysisForm_Load;
            tabControl1.ResumeLayout(false);
            tabPageStats.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            tabPageGraph.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPageStats;
        private SplitContainer splitContainer2;
        private GroupBox groupBoxStats;
        private Label lblRange;
        private Label lblMaximum;
        private Label lblMinimum;
        private Label lblStdDev;
        private Label lblVariance;
        private Label lblMode;
        private Label lblMedian;
        private Label lblMean;
        private Label lblAnalisicResult;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridViewResults;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private TabPage tabPageGraph;
        private Panel paintPanel;
    }
}