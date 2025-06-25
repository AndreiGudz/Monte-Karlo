// Форма "О программе" - отображает информацию о версии приложения
// и предоставляет ссылку на GitHub разработчика
using System.Diagnostics;
using System.Reflection;

namespace Monte_Karlo
{
    public partial class AboutProgramForm : Form
    {
        // Инициализирует форму и устанавливает текущую версию приложения
        public AboutProgramForm()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            versionLabel.Text = $"Версия: {version.Major}.{version.Minor}.{version.Build}.{version.MinorRevision}";
        }

        // Закрывает форму при нажатии на кнопку
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Открывает ссылку на GitHub разработчика в браузере по умолчанию
        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Открываем ссылку в браузере по умолчанию
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/AndreiGudz",
                    UseShellExecute = true
                });
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