using SmartKids.Enums;
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
    public partial class add_user : Form
    {
        public add_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gender gen;

            if(radioButton1.Checked)
                gen = Gender.Boy;
            else 
                gen = Gender.Girl;



            if (Program.dataset.New_User(textBox1.Text, textBox2.Text, gen)) ;
            else
                MessageBox.Show("Такой пользователь уже есть");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
