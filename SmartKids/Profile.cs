using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKids
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Location = new System.Drawing.Point(10, i * 30);
                picBox.Size = new System.Drawing.Size(20, 20);
                picBox.TabStop = false;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.BorderStyle = BorderStyle.Fixed3D;

               
                this.Controls.Add(picBox);
            }
        }
    }
}
