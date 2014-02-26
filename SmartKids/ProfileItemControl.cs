using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SmartKids
{
    public partial class ProfileItemControl : UserControl
    {
        public ProfileItemControl()
        {
            InitializeComponent();
            Random r = new Random();
            Thread.Sleep(4);
            Colors c = (Colors)r.Next(0,9);
            BackColor = Color.FromName(c.ToString());

            pictureBox1.Click += pictureBox1_Click;
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        public event EventHandler Click;


        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Text
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

    }

    enum Colors
    {
        Pink,
        Green,
        Blue,
        Navy,
        Yellow,
        Orange,
        Coral,
        Indigo,
        Red
    }
}
