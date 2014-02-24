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
    public partial class Add_subcategory : Form
    {

        string picturePath;
        public Add_subcategory()
        {
            InitializeComponent();
        }


        private void Add_subcategory_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Program.dataset.GetCat_name();
               

        }

        private void Load_cat()
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Task Task = new Add_Task();
            Task.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string category = comboBox1.SelectedItem.ToString();


            
            
            
            //По name категории найти id 


        }


        //Добавление новой подкатегории
        private void Add_new_sub_cat(string name_cat,string name_sub)
        {


            string newname = picturePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (textBox1.Text != String.Empty && picturePath != String.Empty)
            {

                if (!Directory.Exists("SubcategoryRecource"))
                {
                    Directory.CreateDirectory("SubcategoryRecource");
                    if (!File.Exists("SubcategoryRecource/" + newname))
                    {
                        File.Copy(picturePath, "SubcategoryRecource/" + newname);
                    }
                }
                else
                {
                    File.Copy(picturePath, "SubcategoryRecource");
                }


               // Program.dataset.AddCategory(name, "SubcategoryRecource/" + newname);
            }
        }





    }
}
