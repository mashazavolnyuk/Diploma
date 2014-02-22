using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SmartKids
{
    public partial class Add_category : Form
    {
        string picturePath;

        public Add_category()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        private void Add_new_cat(string name)
        {


            string newname = picturePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (textBox1.Text != String.Empty && picturePath != String.Empty)
            {

                if (!Directory.Exists("CategoryRecource"))
                {
                    Directory.CreateDirectory("CategoryResource");
                    if (!File.Exists("CategoryResource/" + newname))
                    {
                        File.Copy(picturePath, "CategoryResource/" + newname);
                    }
                }
                else
                {
                    File.Copy(picturePath, "CategoryResource");
                }

                Program.dataset.AddCategory(name, "CategoryResource/" + newname);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picturePath = openFileDialog1.FileName;

                button1.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_subcategory sub = new Add_subcategory();
            sub.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_new_cat(textBox1.Text);
        }
    }
}
