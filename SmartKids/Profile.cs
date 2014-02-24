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
    public partial class Profile : Form
    {   
       private string name_user;
       //Загрузка сатегорий в лист
       List<int> cat = new List<int>();//id категорий
       


        public Profile(string Name_user)
        {
           
            InitializeComponent();
            Show_profile( Name_user);
            cat = Program.dataset.GetCat_ID();
                      
        }

        private void Show_profile(string Name_user)
        {

            label1.Text = Name_user;
        }


        private void Profile_Load(object sender, EventArgs e)
        {
            //Отображаем имеющиеся категории

            for (int i = 0; i < cat.Count; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Size = new Size(120,120);
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                picBox.Image = Image.FromFile(Program.dataset.Get_Resurs(cat[i]));
                    picBox.Tag = cat[i];
                picBox.Click += picBox_Click;
                tableLayoutPanel1.Controls.Add(picBox);
            }
        }




        void picBox_Click(object sender, EventArgs e)
        {
            Show_subcat s = new Show_subcat((int)(sender as PictureBox).Tag);
            s.Show();
        }

        private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            for (int q = 0; q < tableLayoutPanel1.RowStyles.Count; q++)
            {
                tableLayoutPanel1.RowStyles[q].Height = 120;
            }
        }

    }
}
