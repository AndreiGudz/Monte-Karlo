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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            paintPanel = new Panel();
            controlPanel = new Panel();
            buttonsPanel = new Panel();
            btnClear = new Button();
            btnGeneratePoints = new Button();
            resultPanel = new Panel();
            monteCarloSquareLabel = new Label();
            realSquareLabel = new Label();
            checkBoxPanel = new Panel();
            showMessageCheckBox = new CheckBox();
            horizontalCheckBox = new CheckBox();
            circlePositionPanel = new Panel();
            yLabel = new Label();
            yNumericUpDown = new NumericUpDown();
            xLabel = new Label();
            xNumericUpDown = new NumericUpDown();
            pointCountPanel = new Panel();
            pointsCountUpdown = new NumericUpDown();
            pointsCountLabel = new Label();
            constantLinePanel = new Panel();
            cTrackBar = new TrackBar();
            cLabel = new Label();
            scalePpanel = new Panel();
            scaleTrackBar = new TrackBar();
            scaleLabel = new Label();
            radiusPanel = new Panel();
            radiusTrackBar = new TrackBar();
            radiusLabel = new Label();
            controlPanelLabel = new Label();
            menuStrip = new MenuStrip();
            programHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutProgramToolStripMenuItem = new ToolStripMenuItem();
            analysisOfResultsToolStripMenuItem = new ToolStripMenuItem();
            dataManagementToolStripMenuItem = new ToolStripMenuItem();
            closeProgramToolStripMenuItem = new ToolStripMenuItem();
            controlPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            resultPanel.SuspendLayout();
            checkBoxPanel.SuspendLayout();
            circlePositionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)yNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xNumericUpDown).BeginInit();
            pointCountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pointsCountUpdown).BeginInit();
            constantLinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cTrackBar).BeginInit();
            scalePpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scaleTrackBar).BeginInit();
            radiusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radiusTrackBar).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // paintPanel
            // 
            paintPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            paintPanel.BorderStyle = BorderStyle.FixedSingle;
            paintPanel.Location = new Point(541, 55);
            paintPanel.Margin = new Padding(4);
            paintPanel.Name = "paintPanel";
            paintPanel.Size = new Size(865, 999);
            paintPanel.TabIndex = 0;
            paintPanel.Paint += paintPanel_Paint;
            paintPanel.Resize += paintPanel_Resize;
            // 
            // controlPanel
            // 
            controlPanel.AutoScroll = true;
            controlPanel.BackColor = SystemColors.ActiveCaption;
            controlPanel.BorderStyle = BorderStyle.Fixed3D;
            controlPanel.Controls.Add(buttonsPanel);
            controlPanel.Controls.Add(resultPanel);
            controlPanel.Controls.Add(checkBoxPanel);
            controlPanel.Controls.Add(circlePositionPanel);
            controlPanel.Controls.Add(pointCountPanel);
            controlPanel.Controls.Add(constantLinePanel);
            controlPanel.Controls.Add(scalePpanel);
            controlPanel.Controls.Add(radiusPanel);
            controlPanel.Controls.Add(controlPanelLabel);
            controlPanel.Dock = DockStyle.Left;
            controlPanel.Location = new Point(0, 38);
            controlPanel.Margin = new Padding(4);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(533, 1029);
            controlPanel.TabIndex = 1;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = SystemColors.ActiveCaption;
            buttonsPanel.Controls.Add(btnClear);
            buttonsPanel.Controls.Add(btnGeneratePoints);
            buttonsPanel.Location = new Point(15, 781);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(474, 108);
            buttonsPanel.TabIndex = 4;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(260, 13);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(196, 82);
            btnClear.TabIndex = 1;
            btnClear.Text = "Очистить\r\nточки";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnGeneratePoints
            // 
            btnGeneratePoints.Location = new Point(15, 13);
            btnGeneratePoints.Name = "btnGeneratePoints";
            btnGeneratePoints.Size = new Size(196, 82);
            btnGeneratePoints.TabIndex = 0;
            btnGeneratePoints.Text = "Генерировать\r\nточки";
            btnGeneratePoints.UseVisualStyleBackColor = true;
            btnGeneratePoints.Click += btnGeneratePoints_Click;
            // 
            // resultPanel
            // 
            resultPanel.BackColor = SystemColors.ActiveCaption;
            resultPanel.Controls.Add(monteCarloSquareLabel);
            resultPanel.Controls.Add(realSquareLabel);
            resultPanel.Location = new Point(15, 895);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(474, 122);
            resultPanel.TabIndex = 9;
            // 
            // monteCarloSquareLabel
            // 
            monteCarloSquareLabel.BackColor = Color.White;
            monteCarloSquareLabel.Location = new Point(15, 58);
            monteCarloSquareLabel.Margin = new Padding(4, 0, 4, 0);
            monteCarloSquareLabel.Name = "monteCarloSquareLabel";
            monteCarloSquareLabel.Size = new Size(441, 40);
            monteCarloSquareLabel.TabIndex = 3;
            monteCarloSquareLabel.Text = "Площадь методом Монте-Карло:";
            // 
            // realSquareLabel
            // 
            realSquareLabel.BackColor = Color.White;
            realSquareLabel.Location = new Point(15, 17);
            realSquareLabel.Margin = new Padding(4, 0, 4, 0);
            realSquareLabel.Name = "realSquareLabel";
            realSquareLabel.Size = new Size(441, 40);
            realSquareLabel.TabIndex = 2;
            realSquareLabel.Text = "Площадь секции аналитически:";
            // 
            // checkBoxPanel
            // 
            checkBoxPanel.BackColor = SystemColors.ActiveCaption;
            checkBoxPanel.Controls.Add(showMessageCheckBox);
            checkBoxPanel.Controls.Add(horizontalCheckBox);
            checkBoxPanel.Location = new Point(15, 672);
            checkBoxPanel.Name = "checkBoxPanel";
            checkBoxPanel.Size = new Size(474, 100);
            checkBoxPanel.TabIndex = 8;
            // 
            // showMessageCheckBox
            // 
            showMessageCheckBox.BackColor = Color.White;
            showMessageCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            showMessageCheckBox.Location = new Point(15, 52);
            showMessageCheckBox.Name = "showMessageCheckBox";
            showMessageCheckBox.Size = new Size(441, 40);
            showMessageCheckBox.TabIndex = 6;
            showMessageCheckBox.Text = "Показывать результат вычислений";
            showMessageCheckBox.UseVisualStyleBackColor = false;
            // 
            // horizontalCheckBox
            // 
            horizontalCheckBox.BackColor = Color.White;
            horizontalCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            horizontalCheckBox.Checked = true;
            horizontalCheckBox.CheckState = CheckState.Checked;
            horizontalCheckBox.Location = new Point(15, 11);
            horizontalCheckBox.Name = "horizontalCheckBox";
            horizontalCheckBox.Size = new Size(441, 40);
            horizontalCheckBox.TabIndex = 5;
            horizontalCheckBox.Text = "Направление горизонтальное: ";
            horizontalCheckBox.UseVisualStyleBackColor = false;
            horizontalCheckBox.CheckedChanged += horizontalCheckBox_CheckedChanged;
            // 
            // circlePositionPanel
            // 
            circlePositionPanel.BackColor = SystemColors.ActiveCaption;
            circlePositionPanel.Controls.Add(yLabel);
            circlePositionPanel.Controls.Add(yNumericUpDown);
            circlePositionPanel.Controls.Add(xLabel);
            circlePositionPanel.Controls.Add(xNumericUpDown);
            circlePositionPanel.Location = new Point(15, 71);
            circlePositionPanel.Name = "circlePositionPanel";
            circlePositionPanel.Size = new Size(474, 70);
            circlePositionPanel.TabIndex = 7;
            // 
            // yLabel
            // 
            yLabel.BackColor = Color.White;
            yLabel.Font = new Font("Segoe UI", 12F);
            yLabel.Location = new Point(270, 15);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(41, 39);
            yLabel.TabIndex = 3;
            yLabel.Text = "Y:";
            // 
            // yNumericUpDown
            // 
            yNumericUpDown.Font = new Font("Segoe UI", 10F);
            yNumericUpDown.Location = new Point(316, 15);
            yNumericUpDown.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            yNumericUpDown.Name = "yNumericUpDown";
            yNumericUpDown.Size = new Size(140, 39);
            yNumericUpDown.TabIndex = 2;
            yNumericUpDown.ValueChanged += yNumericUpDown_ValueChanged;
            // 
            // xLabel
            // 
            xLabel.BackColor = Color.White;
            xLabel.Font = new Font("Segoe UI", 12F);
            xLabel.Location = new Point(15, 15);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(41, 39);
            xLabel.TabIndex = 1;
            xLabel.Text = "X: ";
            // 
            // xNumericUpDown
            // 
            xNumericUpDown.Font = new Font("Segoe UI", 10F);
            xNumericUpDown.Location = new Point(61, 15);
            xNumericUpDown.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            xNumericUpDown.Name = "xNumericUpDown";
            xNumericUpDown.Size = new Size(140, 39);
            xNumericUpDown.TabIndex = 0;
            xNumericUpDown.ValueChanged += xNumericUpDown_ValueChanged;
            // 
            // pointCountPanel
            // 
            pointCountPanel.BackColor = SystemColors.ActiveCaption;
            pointCountPanel.Controls.Add(pointsCountUpdown);
            pointCountPanel.Controls.Add(pointsCountLabel);
            pointCountPanel.Location = new Point(15, 301);
            pointCountPanel.Margin = new Padding(4);
            pointCountPanel.Name = "pointCountPanel";
            pointCountPanel.Size = new Size(474, 58);
            pointCountPanel.TabIndex = 3;
            // 
            // pointsCountUpdown
            // 
            pointsCountUpdown.Location = new Point(271, 13);
            pointsCountUpdown.Margin = new Padding(4);
            pointsCountUpdown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            pointsCountUpdown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pointsCountUpdown.Name = "pointsCountUpdown";
            pointsCountUpdown.Size = new Size(185, 35);
            pointsCountUpdown.TabIndex = 3;
            pointsCountUpdown.TextAlign = HorizontalAlignment.Right;
            pointsCountUpdown.ThousandsSeparator = true;
            pointsCountUpdown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            pointsCountUpdown.ValueChanged += pointsCountUpdown_ValueChanged;
            // 
            // pointsCountLabel
            // 
            pointsCountLabel.BackColor = Color.White;
            pointsCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            pointsCountLabel.Location = new Point(15, 8);
            pointsCountLabel.Margin = new Padding(4, 0, 4, 0);
            pointsCountLabel.Name = "pointsCountLabel";
            pointsCountLabel.Size = new Size(225, 40);
            pointsCountLabel.TabIndex = 2;
            pointsCountLabel.Text = "Количество точек:";
            pointsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // constantLinePanel
            // 
            constantLinePanel.BackColor = SystemColors.ActiveCaption;
            constantLinePanel.Controls.Add(cTrackBar);
            constantLinePanel.Controls.Add(cLabel);
            constantLinePanel.Location = new Point(15, 369);
            constantLinePanel.Margin = new Padding(4);
            constantLinePanel.Name = "constantLinePanel";
            constantLinePanel.Size = new Size(474, 145);
            constantLinePanel.TabIndex = 3;
            // 
            // cTrackBar
            // 
            cTrackBar.BackColor = Color.White;
            cTrackBar.LargeChange = 1;
            cTrackBar.Location = new Point(15, 55);
            cTrackBar.Margin = new Padding(4);
            cTrackBar.Maximum = 42;
            cTrackBar.Minimum = -42;
            cTrackBar.Name = "cTrackBar";
            cTrackBar.Size = new Size(441, 80);
            cTrackBar.TabIndex = 0;
            cTrackBar.Value = 1;
            cTrackBar.ValueChanged += cTrackbar_ValueChanged;
            // 
            // cLabel
            // 
            cLabel.BackColor = Color.White;
            cLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cLabel.Location = new Point(15, 14);
            cLabel.Margin = new Padding(4, 0, 4, 0);
            cLabel.Name = "cLabel";
            cLabel.Size = new Size(441, 40);
            cLabel.TabIndex = 2;
            cLabel.Text = "Значение C: ";
            cLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scalePpanel
            // 
            scalePpanel.BackColor = SystemColors.ActiveCaption;
            scalePpanel.Controls.Add(scaleTrackBar);
            scalePpanel.Controls.Add(scaleLabel);
            scalePpanel.Location = new Point(15, 523);
            scalePpanel.Margin = new Padding(4);
            scalePpanel.Name = "scalePpanel";
            scalePpanel.Size = new Size(474, 140);
            scalePpanel.TabIndex = 3;
            // 
            // scaleTrackBar
            // 
            scaleTrackBar.AutoSize = false;
            scaleTrackBar.BackColor = Color.White;
            scaleTrackBar.Location = new Point(15, 51);
            scaleTrackBar.Margin = new Padding(4);
            scaleTrackBar.Maximum = 150;
            scaleTrackBar.Minimum = 10;
            scaleTrackBar.Name = "scaleTrackBar";
            scaleTrackBar.Size = new Size(441, 70);
            scaleTrackBar.SmallChange = 5;
            scaleTrackBar.TabIndex = 0;
            scaleTrackBar.TickFrequency = 5;
            scaleTrackBar.UseWaitCursor = true;
            scaleTrackBar.Value = 15;
            scaleTrackBar.Scroll += scaleTrackbar_Scroll;
            // 
            // scaleLabel
            // 
            scaleLabel.BackColor = Color.White;
            scaleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            scaleLabel.Location = new Point(15, 10);
            scaleLabel.Margin = new Padding(4, 0, 4, 0);
            scaleLabel.Name = "scaleLabel";
            scaleLabel.Size = new Size(441, 40);
            scaleLabel.TabIndex = 2;
            scaleLabel.Text = "Масштаб: ";
            scaleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radiusPanel
            // 
            radiusPanel.BackColor = SystemColors.ActiveCaption;
            radiusPanel.Controls.Add(radiusTrackBar);
            radiusPanel.Controls.Add(radiusLabel);
            radiusPanel.Location = new Point(15, 150);
            radiusPanel.Margin = new Padding(4);
            radiusPanel.Name = "radiusPanel";
            radiusPanel.Size = new Size(474, 140);
            radiusPanel.TabIndex = 1;
            // 
            // radiusTrackBar
            // 
            radiusTrackBar.BackColor = Color.White;
            radiusTrackBar.LargeChange = 1;
            radiusTrackBar.Location = new Point(15, 52);
            radiusTrackBar.Margin = new Padding(4);
            radiusTrackBar.Maximum = 20;
            radiusTrackBar.Minimum = 1;
            radiusTrackBar.Name = "radiusTrackBar";
            radiusTrackBar.Size = new Size(441, 80);
            radiusTrackBar.TabIndex = 0;
            radiusTrackBar.Value = 1;
            radiusTrackBar.Scroll += radiusSlider_Scroll;
            // 
            // radiusLabel
            // 
            radiusLabel.BackColor = Color.White;
            radiusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radiusLabel.Location = new Point(15, 11);
            radiusLabel.Margin = new Padding(4, 0, 4, 0);
            radiusLabel.Name = "radiusLabel";
            radiusLabel.Size = new Size(441, 40);
            radiusLabel.TabIndex = 2;
            radiusLabel.Text = "Радиус круга: ";
            radiusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // controlPanelLabel
            // 
            controlPanelLabel.BackColor = Color.Transparent;
            controlPanelLabel.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point, 204);
            controlPanelLabel.Location = new Point(15, 13);
            controlPanelLabel.Margin = new Padding(4, 0, 4, 0);
            controlPanelLabel.Name = "controlPanelLabel";
            controlPanelLabel.Size = new Size(450, 55);
            controlPanelLabel.TabIndex = 0;
            controlPanelLabel.Text = "Панель управления";
            controlPanelLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(28, 28);
            menuStrip.Items.AddRange(new ToolStripItem[] { programHelpToolStripMenuItem, aboutProgramToolStripMenuItem, analysisOfResultsToolStripMenuItem, dataManagementToolStripMenuItem, closeProgramToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1419, 38);
            menuStrip.TabIndex = 4;
            menuStrip.Text = "menuStrip1";
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
            // analysisOfResultsToolStripMenuItem
            // 
            analysisOfResultsToolStripMenuItem.Name = "analysisOfResultsToolStripMenuItem";
            analysisOfResultsToolStripMenuItem.Size = new Size(222, 34);
            analysisOfResultsToolStripMenuItem.Text = "Анализ результатов";
            analysisOfResultsToolStripMenuItem.Click += analysisOfResultsToolStripMenuItem_Click;
            // 
            // dataManagementToolStripMenuItem
            // 
            dataManagementToolStripMenuItem.Name = "dataManagementToolStripMenuItem";
            dataManagementToolStripMenuItem.Size = new Size(313, 34);
            dataManagementToolStripMenuItem.Text = "Управление эксперементами";
            dataManagementToolStripMenuItem.Click += dataManagementToolStripMenuItem_Click;
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
            ClientSize = new Size(1419, 1067);
            Controls.Add(controlPanel);
            Controls.Add(paintPanel);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Основное окно";
            FormClosed += MainForm_FormClosed;
            controlPanel.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            checkBoxPanel.ResumeLayout(false);
            circlePositionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)yNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)xNumericUpDown).EndInit();
            pointCountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pointsCountUpdown).EndInit();
            constantLinePanel.ResumeLayout(false);
            constantLinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cTrackBar).EndInit();
            scalePpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scaleTrackBar).EndInit();
            radiusPanel.ResumeLayout(false);
            radiusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radiusTrackBar).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel paintPanel;
        private Panel controlPanel;
        private Label controlPanelLabel;
        private Panel radiusPanel;
        private Label radiusLabel;
        public TrackBar radiusTrackBar;
        private Panel pointCountPanel;
        private Label pointsCountLabel;
        private Panel scalePpanel;
        public TrackBar scaleTrackBar;
        private Label scaleLabel;
        private NumericUpDown pointsCountUpdown;
        private Panel constantLinePanel;
        public TrackBar cTrackBar;
        private Label cLabel;
        private Label realSquareLabel;
        private Label monteCarloSquareLabel;
        private CheckBox horizontalCheckBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem programHelpToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
        private ToolStripMenuItem closeProgramToolStripMenuItem;
        private CheckBox showMessageCheckBox;
        private Panel circlePositionPanel;
        private Label yLabel;
        private NumericUpDown yNumericUpDown;
        private Label xLabel;
        private NumericUpDown xNumericUpDown;
        private ToolStripMenuItem analysisOfResultsToolStripMenuItem;
        private Panel checkBoxPanel;
        private Panel resultPanel;
        private Panel buttonsPanel;
        private Button btnGeneratePoints;
        private Button btnClear;
        private ToolStripMenuItem dataManagementToolStripMenuItem;
    }
}