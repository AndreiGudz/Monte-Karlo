using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Karlo
{
    public partial class MainForm : Form
    {
        private Form _parentForm;

        private PointF offset = new(0, 0);
        private float radius = 2;
        private int count = 10000;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            MonteCarloCalculator.GenerateRandomPoints(radius, count);
        }

        public MainForm(Form parentForm) : this()
        {
            _parentForm = parentForm;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            MonteCarloView.RenderToBuffer(this, e, radius, offset);
            base.OnPaint(e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.panel1.Width = this.panel1.Height;
        }
    }
}
