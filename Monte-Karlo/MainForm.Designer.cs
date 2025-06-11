namespace Monte_Karlo
{
    partial class MainForm
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
            paintPanel = new Panel();
            panel2 = new Panel();
            showMessageCheckBox = new CheckBox();
            MonteCarloSquare = new Label();
            horizontalCheckBox = new CheckBox();
            realSquareLabel = new Label();
            panel6 = new Panel();
            cTrackBar = new TrackBar();
            cLabel = new Label();
            panel5 = new Panel();
            scaleTrackBar = new TrackBar();
            scaleLabel = new Label();
            panel4 = new Panel();
            pointsCountUpdown = new NumericUpDown();
            pointsCountLabel = new Label();
            panel3 = new Panel();
            radiusTrackBar = new TrackBar();
            radiusLabel = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            programHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutProgramToolStripMenuItem = new ToolStripMenuItem();
            управлениеToolStripMenuItem = new ToolStripMenuItem();
            сгенерироватьТочкиToolStripMenuItem = new ToolStripMenuItem();
            очиститьТочкиToolStripMenuItem = new ToolStripMenuItem();
            closeProgramToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cTrackBar).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scaleTrackBar).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pointsCountUpdown).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radiusTrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // paintPanel
            // 
            paintPanel.BorderStyle = BorderStyle.FixedSingle;
            paintPanel.Dock = DockStyle.Right;
            paintPanel.Location = new Point(481, 38);
            paintPanel.Margin = new Padding(4);
            paintPanel.Name = "paintPanel";
            paintPanel.Size = new Size(962, 962);
            paintPanel.TabIndex = 0;
            paintPanel.Paint += paintPanel_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(showMessageCheckBox);
            panel2.Controls.Add(MonteCarloSquare);
            panel2.Controls.Add(horizontalCheckBox);
            panel2.Controls.Add(realSquareLabel);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 38);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(401, 962);
            panel2.TabIndex = 1;
            // 
            // showMessageCheckBox
            // 
            showMessageCheckBox.AutoSize = true;
            showMessageCheckBox.Location = new Point(8, 694);
            showMessageCheckBox.Name = "showMessageCheckBox";
            showMessageCheckBox.Size = new Size(169, 34);
            showMessageCheckBox.TabIndex = 6;
            showMessageCheckBox.Text = "showMessage";
            showMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // MonteCarloSquare
            // 
            MonteCarloSquare.AutoSize = true;
            MonteCarloSquare.Location = new Point(12, 883);
            MonteCarloSquare.Margin = new Padding(4, 0, 4, 0);
            MonteCarloSquare.Name = "MonteCarloSquare";
            MonteCarloSquare.Size = new Size(203, 30);
            MonteCarloSquare.TabIndex = 3;
            MonteCarloSquare.Text = "Monte Carlo Square:";
            // 
            // horizontalCheckBox
            // 
            horizontalCheckBox.AutoSize = true;
            horizontalCheckBox.Checked = true;
            horizontalCheckBox.CheckState = CheckState.Checked;
            horizontalCheckBox.Location = new Point(10, 654);
            horizontalCheckBox.Name = "horizontalCheckBox";
            horizontalCheckBox.Size = new Size(132, 34);
            horizontalCheckBox.TabIndex = 5;
            horizontalCheckBox.Text = "horizontal";
            horizontalCheckBox.UseVisualStyleBackColor = true;
            horizontalCheckBox.CheckedChanged += horizontalCheckBox_CheckedChanged;
            // 
            // realSquareLabel
            // 
            realSquareLabel.AutoSize = true;
            realSquareLabel.Location = new Point(16, 837);
            realSquareLabel.Margin = new Padding(4, 0, 4, 0);
            realSquareLabel.Name = "realSquareLabel";
            realSquareLabel.Size = new Size(127, 30);
            realSquareLabel.TabIndex = 2;
            realSquareLabel.Text = "Real Square:";
            // 
            // panel6
            // 
            panel6.Controls.Add(cTrackBar);
            panel6.Controls.Add(cLabel);
            panel6.Location = new Point(5, 329);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(360, 144);
            panel6.TabIndex = 3;
            // 
            // cTrackBar
            // 
            cTrackBar.LargeChange = 1;
            cTrackBar.Location = new Point(4, 51);
            cTrackBar.Margin = new Padding(4);
            cTrackBar.Maximum = 42;
            cTrackBar.Minimum = -42;
            cTrackBar.Name = "cTrackBar";
            cTrackBar.Size = new Size(351, 80);
            cTrackBar.TabIndex = 0;
            cTrackBar.Value = 1;
            cTrackBar.ValueChanged += cTrackbar_ValueChanged;
            // 
            // cLabel
            // 
            cLabel.BackColor = Color.Transparent;
            cLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cLabel.Location = new Point(0, 0);
            cLabel.Margin = new Padding(4, 0, 4, 0);
            cLabel.Name = "cLabel";
            cLabel.Size = new Size(360, 46);
            cLabel.TabIndex = 2;
            cLabel.Text = "C";
            cLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.Controls.Add(scaleTrackBar);
            panel5.Controls.Add(scaleLabel);
            panel5.Location = new Point(8, 490);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(360, 144);
            panel5.TabIndex = 3;
            // 
            // scaleTrackBar
            // 
            scaleTrackBar.AutoSize = false;
            scaleTrackBar.Location = new Point(4, 51);
            scaleTrackBar.Margin = new Padding(4);
            scaleTrackBar.Maximum = 150;
            scaleTrackBar.Minimum = 10;
            scaleTrackBar.Name = "scaleTrackBar";
            scaleTrackBar.Size = new Size(351, 84);
            scaleTrackBar.SmallChange = 5;
            scaleTrackBar.TabIndex = 0;
            scaleTrackBar.TickFrequency = 5;
            scaleTrackBar.UseWaitCursor = true;
            scaleTrackBar.Value = 15;
            scaleTrackBar.Scroll += scaleTrackbar_Scroll;
            // 
            // scaleLabel
            // 
            scaleLabel.BackColor = Color.Transparent;
            scaleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            scaleLabel.Location = new Point(0, 0);
            scaleLabel.Margin = new Padding(4, 0, 4, 0);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(360, 46);
            scaleLabel.TabIndex = 2;
            scaleLabel.Text = "Scale";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(pointsCountUpdown);
            panel4.Controls.Add(pointsCountLabel);
            panel4.Location = new Point(8, 222);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(360, 99);
            panel4.TabIndex = 3;
            // 
            // pointsCountUpdown
            // 
            pointsCountUpdown.Location = new Point(4, 51);
            pointsCountUpdown.Margin = new Padding(4);
            pointsCountUpdown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            pointsCountUpdown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pointsCountUpdown.Name = "pointsCountUpdown";
            pointsCountUpdown.Size = new Size(351, 35);
            pointsCountUpdown.TabIndex = 3;
            pointsCountUpdown.TextAlign = HorizontalAlignment.Right;
            pointsCountUpdown.ThousandsSeparator = true;
            pointsCountUpdown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            pointsCountUpdown.ValueChanged += pointsCountUpdown_ValueChanged;
            // 
            // pointsCountLabel
            // 
            pointsCountLabel.BackColor = Color.Transparent;
            pointsCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            pointsCountLabel.Location = new Point(0, 0);
            pointsCountLabel.Margin = new Padding(4, 0, 4, 0);
            pointsCountLabel.Name = "pointsCountLabel";
            pointsCountLabel.Size = new Size(360, 46);
            pointsCountLabel.TabIndex = 2;
            pointsCountLabel.Text = "Points Count";
            pointsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(radiusTrackBar);
            panel3.Controls.Add(radiusLabel);
            panel3.Location = new Point(5, 70);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(360, 144);
            panel3.TabIndex = 1;
            // 
            // radiusTrackBar
            // 
            radiusTrackBar.LargeChange = 1;
            radiusTrackBar.Location = new Point(4, 51);
            radiusTrackBar.Margin = new Padding(4);
            radiusTrackBar.Maximum = 20;
            radiusTrackBar.Minimum = 1;
            radiusTrackBar.Name = "radiusTrackBar";
            radiusTrackBar.Size = new Size(351, 80);
            radiusTrackBar.TabIndex = 0;
            radiusTrackBar.Value = 1;
            radiusTrackBar.Scroll += radiusSlider_Scroll;
            // 
            // radiusLabel
            // 
            radiusLabel.BackColor = Color.Transparent;
            radiusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radiusLabel.Location = new Point(0, 0);
            radiusLabel.Margin = new Padding(4, 0, 4, 0);
            radiusLabel.Name = "radiusLabel";
            radiusLabel.Size = new Size(360, 46);
            radiusLabel.TabIndex = 2;
            radiusLabel.Text = "Radius";
            radiusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.Location = new Point(-2, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(375, 66);
            label1.TabIndex = 0;
            label1.Text = "Control panel";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { programHelpToolStripMenuItem, aboutProgramToolStripMenuItem, управлениеToolStripMenuItem, closeProgramToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1443, 38);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // programHelpToolStripMenuItem
            // 
            programHelpToolStripMenuItem.Name = "programHelpToolStripMenuItem";
            programHelpToolStripMenuItem.Size = new Size(111, 34);
            programHelpToolStripMenuItem.Text = "Справка";
            programHelpToolStripMenuItem.Click += programHelpToolStripMenuItem_Click;
            // 
            // aboutProgramToolStripMenuItem
            // 
            aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            aboutProgramToolStripMenuItem.Size = new Size(161, 34);
            aboutProgramToolStripMenuItem.Text = "О программе";
            aboutProgramToolStripMenuItem.Click += aboutProgramToolStripMenuItem_Click;
            // 
            // управлениеToolStripMenuItem
            // 
            управлениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сгенерироватьТочкиToolStripMenuItem, очиститьТочкиToolStripMenuItem });
            управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            управлениеToolStripMenuItem.Size = new Size(146, 34);
            управлениеToolStripMenuItem.Text = "Управление";
            // 
            // сгенерироватьТочкиToolStripMenuItem
            // 
            сгенерироватьТочкиToolStripMenuItem.Name = "сгенерироватьТочкиToolStripMenuItem";
            сгенерироватьТочкиToolStripMenuItem.Size = new Size(337, 40);
            сгенерироватьТочкиToolStripMenuItem.Text = "Сгенерировать точки";
            сгенерироватьТочкиToolStripMenuItem.Click += сгенерироватьТочкиToolStripMenuItem_Click;
            // 
            // очиститьТочкиToolStripMenuItem
            // 
            очиститьТочкиToolStripMenuItem.Name = "очиститьТочкиToolStripMenuItem";
            очиститьТочкиToolStripMenuItem.Size = new Size(337, 40);
            очиститьТочкиToolStripMenuItem.Text = "Очистить точки";
            очиститьТочкиToolStripMenuItem.Click += очиститьТочкиToolStripMenuItem_Click;
            // 
            // closeProgramToolStripMenuItem
            // 
            closeProgramToolStripMenuItem.Name = "closeProgramToolStripMenuItem";
            closeProgramToolStripMenuItem.Size = new Size(237, 34);
            closeProgramToolStripMenuItem.Text = "Закрыть приложение";
            closeProgramToolStripMenuItem.Click += closeProgramToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 1000);
            Controls.Add(panel2);
            Controls.Add(paintPanel);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cTrackBar).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scaleTrackBar).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pointsCountUpdown).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radiusTrackBar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel paintPanel;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Label radiusLabel;
        public TrackBar radiusTrackBar;
        private Panel panel4;
        private Label pointsCountLabel;
        private Panel panel5;
        public TrackBar scaleTrackBar;
        private Label scaleLabel;
        private NumericUpDown pointsCountUpdown;
        private Panel panel6;
        public TrackBar cTrackBar;
        private Label cLabel;
        private Label realSquareLabel;
        private Label MonteCarloSquare;
        private CheckBox horizontalCheckBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem programHelpToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
        private ToolStripMenuItem closeProgramToolStripMenuItem;
        private ToolStripMenuItem управлениеToolStripMenuItem;
        private ToolStripMenuItem сгенерироватьТочкиToolStripMenuItem;
        private ToolStripMenuItem очиститьТочкиToolStripMenuItem;
        private CheckBox showMessageCheckBox;
    }
}