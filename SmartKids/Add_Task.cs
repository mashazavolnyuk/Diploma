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
    public partial class Add_Task : Win8Form
    {

        string picturePath;
        string Catalog = "TaskRecource";
        private string selNmae;
        public Add_Task(string name)
        {
            InitializeComponent();
            selNmae = name;
        }

        private void Add_Task_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Program.dataset.Get_SUB_Cat_name();
            comboBox1.SelectedItem = selNmae;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picturePath = openFileDialog1.FileName;
                try
                {
                    Bitmap b = new Bitmap(picturePath);

                    pictureBox1.Image = b;
                }
                catch (Exception)
                {
                    MessageBox.Show("Выбранный файл - не изображение");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   string sub=comboBox1.SelectedItem.ToString();
            Program.dataset.Add_Task(textBox1.Text,textBox2.Text,sub,Catalog+picturePath);
            MessageBox.Show("Добавлено");
        }
    }
}
