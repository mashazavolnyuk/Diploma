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
        string Catalog = "SubcategoryRecource";
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
            int id_category=Program.dataset.Search_ID_CAT(category);
            Add_new_sub_cat(id_category, textBox1.Text);

        }


        //Добавление новой подкатегории
        private void Add_new_sub_cat(int id_cat,string name_sub)
        {


            string newname = picturePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();


            if (textBox1.Text != String.Empty && picturePath != String.Empty)
            {

                if (!Directory.Exists(Catalog))
                {
                    Directory.CreateDirectory(Catalog);
                    if (!File.Exists(Catalog + newname))
                    {
                        File.Copy(picturePath, Catalog + newname);
                    }
                }
                else
                {
                    File.Copy(picturePath, Catalog);
                }

                Program.dataset.SubCategory(id_cat, name_sub, Catalog + newname);
            }
        }





    }
}
