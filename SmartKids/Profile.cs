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
       List<string> cat = new List<string>();
       

        public Profile(string Name_user)
        {
           
            InitializeComponent();
            Show_profile( Name_user);
            cat = Program.dataset.GetCat_Resurs();
                      
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
                 picBox.Image = Image.FromFile(cat[i]);                
                tableLayoutPanel1.Controls.Add(picBox);
            }
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
