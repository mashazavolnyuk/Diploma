using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKids
{
    public class MyForm : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();

        int width, height;
        private Win8BackButton win8BackButton1;

        public MyForm()
        {
            t.Tick += t_Tick;
            t.Interval = 10;

            t2.Tick += t2_Tick;
            t2.Interval = 10;


            width = Size.Width;
            height = Size.Height;

        }

        private void t2_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X - 25, this.Location.Y);


            if (Location.X < 0)
            {
                WindowState = FormWindowState.Maximized;
                t2.Enabled = false;
            }

        }

        void t_Tick(object sender, EventArgs e)
        {

            this.Location = new Point(this.Location.X + 25, this.Location.Y);


            if (Location.X > Size.Width)
            {
                t.Enabled = false;
                Close();
            }


        }

        private void InitializeComponent()
        {
            this.win8BackButton1 = new SmartKids.Win8BackButton();
            this.SuspendLayout();
            // 
            // win8BackButton1
            // 
            this.win8BackButton1.AutoSize = true;
            this.win8BackButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.win8BackButton1.BackColor = System.Drawing.Color.Transparent;
            this.win8BackButton1.Location = new System.Drawing.Point(50, 65);
            this.win8BackButton1.Name = "win8BackButton1";
            this.win8BackButton1.Size = new System.Drawing.Size(41, 41);
            this.win8BackButton1.TabIndex = 0;
            this.win8BackButton1.Click += new System.EventHandler(this.win8BackButton1_Click);
            // 
            // MyForm
            // 
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(813, 515);
            this.Controls.Add(this.win8BackButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            Location = new Point(width + 10, 0);
            WindowState = FormWindowState.Normal;
            Size = new System.Drawing.Size(width, height);

            t2.Enabled = true;

        }

        private void win8BackButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(width, height);
            t.Enabled = true;
        }

    }


}
