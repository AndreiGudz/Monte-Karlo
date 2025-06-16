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
            tabControl1 = new TabControl();
            tabPageStats = new TabPage();
            groupBoxStats = new GroupBox();
            lblRange = new Label();
            lblStdDev = new Label();
            lblVariance = new Label();
            lblMode = new Label();
            lblMedian = new Label();
            lblMean = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPageGraph = new TabPage();
            splitContainer1 = new SplitContainer();
            dataGridViewResults = new DataGridView();
            panelGraph = new Panel();
            lblAnalisicResult = new Label();
            tabControl1.SuspendLayout();
            tabPageStats.SuspendLayout();
            groupBoxStats.SuspendLayout();
            tabPageGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
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
            tabPageStats.Controls.Add(groupBoxStats);
            tabPageStats.Location = new Point(4, 39);
            tabPageStats.Margin = new Padding(5, 6, 5, 6);
            tabPageStats.Name = "tabPageStats";
            tabPageStats.Padding = new Padding(5, 6, 5, 6);
            tabPageStats.Size = new Size(1363, 857);
            tabPageStats.TabIndex = 0;
            tabPageStats.Text = "Statistical Analysis";
            tabPageStats.UseVisualStyleBackColor = true;
            // 
            // groupBoxStats
            // 
            groupBoxStats.Controls.Add(lblAnalisicResult);
            groupBoxStats.Controls.Add(lblRange);
            groupBoxStats.Controls.Add(lblStdDev);
            groupBoxStats.Controls.Add(lblVariance);
            groupBoxStats.Controls.Add(lblMode);
            groupBoxStats.Controls.Add(lblMedian);
            groupBoxStats.Controls.Add(lblMean);
            groupBoxStats.Controls.Add(label7);
            groupBoxStats.Controls.Add(label6);
            groupBoxStats.Controls.Add(label5);
            groupBoxStats.Controls.Add(label4);
            groupBoxStats.Controls.Add(label3);
            groupBoxStats.Controls.Add(label2);
            groupBoxStats.Controls.Add(label1);
            groupBoxStats.Dock = DockStyle.Fill;
            groupBoxStats.Location = new Point(5, 6);
            groupBoxStats.Margin = new Padding(5, 6, 5, 6);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Padding = new Padding(5, 6, 5, 6);
            groupBoxStats.Size = new Size(1353, 845);
            groupBoxStats.TabIndex = 0;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "Measures";
            // 
            // lblRange
            // 
            lblRange.AutoSize = true;
            lblRange.Location = new Point(257, 360);
            lblRange.Margin = new Padding(5, 0, 5, 0);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(21, 30);
            lblRange.TabIndex = 11;
            lblRange.Text = "-";
            // 
            // lblStdDev
            // 
            lblStdDev.AutoSize = true;
            lblStdDev.Location = new Point(257, 300);
            lblStdDev.Margin = new Padding(5, 0, 5, 0);
            lblStdDev.Name = "lblStdDev";
            lblStdDev.Size = new Size(21, 30);
            lblStdDev.TabIndex = 10;
            lblStdDev.Text = "-";
            // 
            // lblVariance
            // 
            lblVariance.AutoSize = true;
            lblVariance.Location = new Point(257, 240);
            lblVariance.Margin = new Padding(5, 0, 5, 0);
            lblVariance.Name = "lblVariance";
            lblVariance.Size = new Size(21, 30);
            lblVariance.TabIndex = 9;
            lblVariance.Text = "-";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(257, 180);
            lblMode.Margin = new Padding(5, 0, 5, 0);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(21, 30);
            lblMode.TabIndex = 8;
            lblMode.Text = "-";
            // 
            // lblMedian
            // 
            lblMedian.AutoSize = true;
            lblMedian.Location = new Point(257, 120);
            lblMedian.Margin = new Padding(5, 0, 5, 0);
            lblMedian.Name = "lblMedian";
            lblMedian.Size = new Size(21, 30);
            lblMedian.TabIndex = 7;
            lblMedian.Text = "-";
            // 
            // lblMean
            // 
            lblMean.AutoSize = true;
            lblMean.Location = new Point(257, 60);
            lblMean.Margin = new Padding(5, 0, 5, 0);
            lblMean.Name = "lblMean";
            lblMean.Size = new Size(21, 30);
            lblMean.TabIndex = 6;
            lblMean.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 420);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(158, 30);
            label7.TabIndex = 12;
            label7.Text = "Analistic Result:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 360);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(77, 30);
            label6.TabIndex = 5;
            label6.Text = "Range:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 300);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(194, 30);
            label5.TabIndex = 4;
            label5.Text = "Standard Deviation:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 240);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 30);
            label4.TabIndex = 3;
            label4.Text = "Variance:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 180);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 30);
            label3.TabIndex = 2;
            label3.Text = "Mode:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 30);
            label2.TabIndex = 1;
            label2.Text = "Median:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 60);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 30);
            label1.TabIndex = 0;
            label1.Text = "Mean:";
            // 
            // tabPageGraph
            // 
            tabPageGraph.Controls.Add(splitContainer1);
            tabPageGraph.Location = new Point(4, 39);
            tabPageGraph.Margin = new Padding(5, 6, 5, 6);
            tabPageGraph.Name = "tabPageGraph";
            tabPageGraph.Padding = new Padding(5, 6, 5, 6);
            tabPageGraph.Size = new Size(1363, 857);
            tabPageGraph.TabIndex = 1;
            tabPageGraph.Text = "Graphical Analysis";
            tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(5, 6);
            splitContainer1.Margin = new Padding(5, 6, 5, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewResults);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelGraph);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(1353, 845);
            splitContainer1.SplitterDistance = 961;
            splitContainer1.SplitterWidth = 8;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Dock = DockStyle.Fill;
            dataGridViewResults.Location = new Point(0, 0);
            dataGridViewResults.Margin = new Padding(5, 6, 5, 6);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 72;
            dataGridViewResults.RowTemplate.Height = 25;
            dataGridViewResults.Size = new Size(961, 845);
            dataGridViewResults.TabIndex = 1;
            // 
            // panelGraph
            // 
            panelGraph.Dock = DockStyle.Fill;
            panelGraph.Location = new Point(0, 0);
            panelGraph.Margin = new Padding(5, 6, 5, 6);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new Size(384, 845);
            panelGraph.TabIndex = 1;
            // 
            // lblAnalisicResult
            // 
            lblAnalisicResult.AutoSize = true;
            lblAnalisicResult.Location = new Point(257, 420);
            lblAnalisicResult.Margin = new Padding(5, 0, 5, 0);
            lblAnalisicResult.Name = "lblAnalisicResult";
            lblAnalisicResult.Size = new Size(21, 30);
            lblAnalisicResult.TabIndex = 13;
            lblAnalisicResult.Text = "-";
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(tabControl1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "AnalysisForm";
            Text = "Simulation Results Analysis";
            Load += AnalysisForm_Load;
            tabControl1.ResumeLayout(false);
            tabPageStats.ResumeLayout(false);
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            tabPageGraph.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dataGridViewResults;
        private Panel panelGraph;
        private TabControl tabControl1;
        private TabPage tabPageStats;
        private GroupBox groupBoxStats;
        private Label lblRange;
        private Label lblStdDev;
        private Label lblVariance;
        private Label lblMode;
        private Label lblMedian;
        private Label lblMean;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPageGraph;
        private SplitContainer splitContainer1;
        private Label lblAnalisicResult;
    }
}