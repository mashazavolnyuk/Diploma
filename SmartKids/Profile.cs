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
    public partial class Profile : Win8Form
    {
        private string name_user;
        //Загрузка сатегорий в лист
        List<int> cat = new List<int>();//id категорий
        List<Сategory> LoadCategory = new List<Сategory>();//загруженные категории


        public Profile(string Name_user):base()
        {
            InitializeComponent();
            cat = Program.dataset.GetCat_ID();

            //загружаем категории,количество известно по cat
            for (int i = 0; i < cat.Count(); i++)
            {

              string name = Program.dataset.Get_name_category(cat[i]);
              string picter=Program.dataset.Get_Resurs(cat[i]);

              LoadCategory.Add(new Сategory(name,picter,cat[i]));
            }
            Load_User(Name_user);
            name_user = Name_user;


        }


        private void Load_User(string Name) {
         label1.Text = Name;
         pictureBox1.Image = Image.FromFile(Program.dataset.GetPhopo_USER(Name));

        }



        private void Profile_Load(object sender, EventArgs e)
        {   
             

            //Отображаем имеющиеся категории

            for (int i = 0; i < cat.Count; i++)
            {
               
                ProfileItemControl pit = new ProfileItemControl();
                pit.Image = Image.FromFile(Program.dataset.Get_Resurs(cat[i]));
                pit.Text = cat[i].ToString();
                pit.Tag = cat[i].ToString();
                pit.Click += pit_Click;
                tableLayoutPanel1.Controls.Add(pit);
            }

            tableLayoutPanel1.Focus();
        }



        private void pit_Click(object sender, EventArgs e)
        {
            string tmp = (sender as ProfileItemControl).Tag.ToString();
            Show_subcat s = new Show_subcat(Convert.ToInt32(tmp));
            s.Show();
        }
        void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            for (int q = 0; q < tableLayoutPanel1.RowStyles.Count; q++)
            {
                tableLayoutPanel1.RowStyles[q].Height = 170;
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Indigo;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Play_Game newgame = new Play_Game(name_user);
            newgame.Show();
        }

    }
}
