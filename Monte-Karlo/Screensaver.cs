namespace Monte_Karlo
{
    public partial class Screensaver : Form
    {
        public Screensaver()
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

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MainForm(this);
            this.Hide();
            form.Show();
        }
    }
}
