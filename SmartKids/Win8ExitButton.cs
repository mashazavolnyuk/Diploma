using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKids
{
    public partial class Win8ExitButton : UserControl
    {
        public Win8ExitButton()
        {
            InitializeComponent();
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.Click += pictureBox1_Click;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
                this.Click(this, e);

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.normal;
        }

        public new event EventHandler Click;

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.exitHover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.exitNorm;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.exitPress;
        }

    }
}
