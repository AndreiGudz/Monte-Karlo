using System;
using System.Windows.Forms;

namespace Monte_Karlo
{
    partial class AboutProgramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProgramForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            authorLabel = new Label();
            versionLabel = new Label();
            closeButton = new Button();
            titleLabel = new Label();
            pictureBox1 = new PictureBox();
            githubLinkLabel = new LinkLabel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(authorLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(versionLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(closeButton, 0, 5);
            tableLayoutPanel1.Controls.Add(titleLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(githubLinkLabel, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.No;
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(802, 428);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Dock = DockStyle.Fill;
            authorLabel.Font = new Font("Segoe UI", 10F);
            authorLabel.Location = new Point(0, 100);
            authorLabel.Margin = new Padding(0, 0, 0, 5);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(450, 160);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Автор: Гудзь Андрей Владимирович\r\nСтудент группы ИСП-304 Университетского колледжа информационных технологий им. Разумовского";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Dock = DockStyle.Fill;
            versionLabel.Font = new Font("Segoe UI", 10F);
            versionLabel.Location = new Point(3, 265);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(444, 32);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "Версия: ";
            // 
            // closeButton
            // 
            closeButton.BackColor = SystemColors.ButtonFace;
            tableLayoutPanel1.SetColumnSpan(closeButton, 2);
            closeButton.DialogResult = DialogResult.OK;
            closeButton.Dock = DockStyle.Fill;
            closeButton.Location = new Point(3, 359);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(796, 66);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.DarkBlue;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0, 0, 0, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(450, 90);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Вычислитель площади сегмента окружности";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.ChatGPT_Image_18_июн__2025_г___13_23_30;
            pictureBox1.Location = new Point(453, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel1.SetRowSpan(pictureBox1, 5);
            pictureBox1.Size = new Size(346, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // githubLinkLabel
            // 
            githubLinkLabel.AutoSize = true;
            githubLinkLabel.Dock = DockStyle.Fill;
            githubLinkLabel.Font = new Font("Segoe UI", 10F);
            githubLinkLabel.Location = new Point(3, 297);
            githubLinkLabel.Name = "githubLinkLabel";
            githubLinkLabel.Size = new Size(444, 32);
            githubLinkLabel.TabIndex = 6;
            githubLinkLabel.TabStop = true;
            githubLinkLabel.Text = "GitHub: https://github.com/AndreiGudz";
            githubLinkLabel.LinkClicked += githubLinkLabel_LinkClicked;
            // 
            // AboutProgramForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(842, 468);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(0, 0, 0, 15);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutProgramForm";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "О программе";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label titleLabel;
        private Label authorLabel;
        private Label versionLabel;
        private Button closeButton;
        private PictureBox pictureBox1;
        private LinkLabel githubLinkLabel;
    }
}