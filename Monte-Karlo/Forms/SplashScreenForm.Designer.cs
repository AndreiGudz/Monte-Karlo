﻿namespace Monte_Karlo
{
    partial class SplashScreenForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            startButton = new Button();
            pictureBox1 = new PictureBox();
            authorLabel = new Label();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.FromArgb(174, 206, 180);
            startButton.Font = new Font("Segoe UI", 14F);
            startButton.Location = new Point(15, 469);
            startButton.Name = "startButton";
            startButton.Size = new Size(480, 84);
            startButton.TabIndex = 5;
            startButton.Text = "Перейти к программе";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(571, 566);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(17, 523);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(460, 30);
            authorLabel.TabIndex = 7;
            authorLabel.Text = "Сделал студент группы ИСП-304 Гудзь Андрей";
            // 
            // panel1
            // 
            panel1.Controls.Add(authorLabel);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(510, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 566);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(15, 37);
            label1.Name = "label1";
            label1.Size = new Size(364, 45);
            label1.TabIndex = 9;
            label1.Text = "Данные в варианте 25:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(15, 104);
            label2.Name = "label2";
            label2.Size = new Size(91, 45);
            label2.TabIndex = 10;
            label2.Text = "X0: 3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(15, 169);
            label3.Name = "label3";
            label3.Size = new Size(90, 45);
            label3.TabIndex = 11;
            label3.Text = "Y0: 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(15, 235);
            label4.Name = "label4";
            label4.Size = new Size(74, 45);
            label4.TabIndex = 12;
            label4.Text = "R: 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(15, 295);
            label5.Name = "label5";
            label5.Size = new Size(463, 45);
            label5.TabIndex = 13;
            label5.Text = "Направление: горизонтально";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(15, 358);
            label6.Name = "label6";
            label6.Size = new Size(74, 45);
            label6.TabIndex = 14;
            label6.Text = "C: 2";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // SplashScreenForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1081, 566);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(startButton);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SplashScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заставка";
            Load += Screensaver_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private PictureBox pictureBox1;
        private Label authorLabel;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private System.Windows.Forms.Timer timer1;
    }
}
