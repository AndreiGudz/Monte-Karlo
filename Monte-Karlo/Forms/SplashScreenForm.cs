// ћодуль SplashScreenForm реализует форму заставки (splash screen) приложени€.
// «аставка автоматически закрываетс€ через заданное врем€ или по нажатию кнопки,
// после чего открывает главную форму приложени€.
using System.Diagnostics;

namespace Monte_Karlo
{
    public partial class SplashScreenForm : Form
    {
        private int _time = 0;
        private int _timeout = 3;    // врем€ до автоматического закрыти€ заставки

        // »нициализирует форму заставки и настраивает прозрачность метки автора
        public SplashScreenForm()
        {
            InitializeComponent();
            SetTransparentColor(authorLabel, pictureBox1);
        }

        // ”станавливает прозрачный фон дл€ элемента относительно родител€
        public void SetTransparentColor(Control control, Control parent)
        {
            if (parent == control)
                return;
            control.Parent = parent;
            control.BackColor = Color.Transparent;
        }

        // ќбрабатывает нажатие кнопки, открыва€ главную форму и скрыва€ заставку
        private void startButton_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.WindowState = FormWindowState.Normal;
            form.Show();
            this.Hide();
        }

        // «апускает таймер при загрузке формы заставки
        private void Screensaver_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // ќбрабатывает тик таймера, автоматически закрыва€ заставку по истечении времени
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++_time >= _timeout)
            {
                timer1.Stop();
                startButton.PerformClick();
            }
        }
    }
}