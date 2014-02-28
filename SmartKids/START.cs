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
    public partial class START : Form
    {
        public START()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_user us = new add_user();
            us.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_category Categ = new Add_category();
            Categ.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entry ent = new Entry();
            ent.Show();
        }

        private void win8ExitButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
