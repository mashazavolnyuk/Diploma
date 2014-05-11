using SmartKids.Enums;
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
    public partial class add_user : Win8Form
    {
        string picturePath;
        string newname;
        Gender gen;
        string Catalog = @"Users_Photo\";

        public add_user()
        {
            InitializeComponent();
        }




        private void Add_New_USER(string Name_User, string Pass, Gender g)
        {




            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                //TODO: check picture
                if (picturePath != null)
                {
                    newname = picturePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();
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
                        File.Copy(picturePath, Catalog + newname, true);
                    }

                }


                bool isCrateNewUser;
                if (picturePath != null)
                {
                    isCrateNewUser = Program.dataset.NewUser(textBox1.Text, textBox2.Text, gen, Catalog + newname);
                }
                else
                {
                    isCrateNewUser = Program.dataset.NewUser(textBox1.Text, textBox2.Text, gen);

                }


                if (!isCrateNewUser)
                    MessageBox.Show("Такой пользователь уже есть");


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
                gen = Gender.Boy;
            else
                gen = Gender.Girl;
            Add_New_USER(textBox1.Text, textBox2.Text, gen);


        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
