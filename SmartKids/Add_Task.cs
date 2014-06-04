using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public Add_Task() {

            InitializeComponent();
        
        }

        private void Add_Task_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Program.dataset.GetSubCategoryNames();
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

                    string newname = picturePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();


                    if (!Directory.Exists(Catalog))
                    {
                        Directory.CreateDirectory(Catalog);
                        if (!File.Exists(Catalog + newname))
                        {
                            File.Copy(picturePath, Catalog + newname);
                            picturePath = Catalog + newname;
                        }
                    }
                    else
                    {
                        File.Copy(picturePath, Catalog + newname);
                        picturePath = Catalog + newname;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Выбранный файл - не изображение");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   string sub=comboBox1.SelectedItem.ToString();
            Program.dataset.AddTask(textBox1.Text,textBox2.Text,sub,picturePath);
            MessageBox.Show("Добавлено");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
