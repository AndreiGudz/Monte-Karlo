using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Karlo
{
    public partial class AboutProgramForm : Form
    {
        public AboutProgramForm()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            versionLabel.Text = $"Версия: {version.Major}.{version.Minor}.{version.Build}.{version.MinorRevision}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Открываем ссылку в браузере по умолчанию
                System.Diagnostics.Process.Start("https://github.com/AndreiGudz");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
