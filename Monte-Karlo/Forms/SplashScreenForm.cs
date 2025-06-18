using System.Diagnostics;

namespace Monte_Karlo
{
    public partial class SplashScreenForm : Form
    {
        private int _time = 0;
        private int _timeout = 3;    // время до автоматического закрытия заставки

        public SplashScreenForm()
        {
            InitializeComponent();
            SetTransparentColor(authorLabel, pictureBox1);
        }

        public void SetTransparentColor(Control control, Control parent)
        {
            if (parent == control)
                return;
            control.Parent = parent;
            control.BackColor = Color.Transparent;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.WindowState = FormWindowState.Normal;
            form.Show();
            this.Hide();
        }

        private void Screensaver_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

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
