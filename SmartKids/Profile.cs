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
      

        public Profile(string Name_user)
        {
           
            InitializeComponent();
            Show_profile( Name_user);
            
            
        }


        private void Show_profile(string Name_user)
        {

            label1.Text = Name_user;
            

           

        }


        private void Profile_Load(object sender, EventArgs e)
        {

            List<Сategory> cat = new List<Сategory>();
            

            for (int i = 0; i < 10; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Location = new System.Drawing.Point(10, i * 30);
                picBox.Size = new System.Drawing.Size(40, 40);
                picBox.TabStop = false;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.BorderStyle = BorderStyle.Fixed3D;

                this.Controls.Add(picBox);
            }
        }

    }
}
