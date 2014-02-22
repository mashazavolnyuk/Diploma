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

using System.Net.Mail;



namespace SmartKids
{
    public partial class StartWin : Form
    {

        public StartWin()
        {
            InitializeComponent();
            
        }

        private void StartWin_Load(object sender, EventArgs e)
        {  
            string[] names = Enum.GetNames(typeof (Gender));
            dataSet1.ReadXml("dataBase.xml");
            comboBox1.DataSource = names;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Add_category a = new Add_category();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_user ad_u = new add_user();
            ad_u.Show();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id=(int) e.Row.Cells[0].Value;
            dataSet1.DeleteUser(id);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {   
            
         
            
          
            
            Profile test = new Profile(textBox1.Text);
            test.Show();
        }
    }
}
