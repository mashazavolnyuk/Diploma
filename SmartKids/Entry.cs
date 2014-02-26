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
    public partial class Entry : Win8Form
    {
        bool open_yes = false;
        public Entry()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


            open_yes = Program.dataset.Open_YES(textBox4.Text, textBox5.Text);
            if (open_yes)
            {
                Profile P = new Profile(textBox4.Text);
                P.Show();
            }
            else
            {
                MessageBox.Show("Проверьте правильность данных. Вход невозможен");
            }
        }

        private void win8BackButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

