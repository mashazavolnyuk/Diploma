using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKids
{   
    public partial class Entry : Form
    {
        int width, height;

        bool open_yes=false;
        public Entry()
        {
            InitializeComponent();
            t.Tick += t_Tick;
            t.Interval = 10;

            t2.Tick += t2_Tick;
            t2.Interval = 10;


            width = Size.Width;
            height = Size.Height;
        }

        private void t2_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X -25, this.Location.Y);


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

        private void button1_Click(object sender, EventArgs e)
        {

           
                open_yes = Program.dataset.Open_YES(textBox1.Text, textBox2.Text);
                if (open_yes)
                {
                    Profile P = new Profile(textBox1.Text);
                    P.Show();
                }
                else
                {
                    MessageBox.Show("Проверьте правильность данных.Вход невозможен");
                }
            }

        private void win8BackButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(width, height);
            t.Enabled = true;
            
        }

        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();

        private void Entry_Load(object sender, EventArgs e)
        {
            Location = new Point(width + 10, 0);
            WindowState = FormWindowState.Normal;
            Size = new System.Drawing.Size(width, height);

            t2.Enabled = true;
        }
        
            
        }
    }

