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
    public partial class Show_subcat : Win8Form
    {   
        
        private int Cat;

        //id подкатегорий 
        List<int> subcategory = new List<int>();
       
        public Show_subcat(int cat)
        {
            InitializeComponent();
            this.Cat = cat;
        }


        private void Show_subcat_Load(object sender, EventArgs e)
        {
            Show_subcategory();


        }

        private void pit_Click(object sender, EventArgs e)
        {
            string tmp = (sender as ProfileItemControl).Tag.ToString();
            Show_Task s = new Show_Task(Convert.ToInt32(tmp));
            s.Show();
        }

        private void Show_subcategory() {

         subcategory=Program.dataset.GetSubCategoriesByCategoryId(Cat);//id подкатегорий
            label1.Text = Program.dataset.Categoty.FindBycat_id(Cat).name;

            for (int i = 0; i < subcategory.Count; i++)
            {
                ProfileItemControl pit = new ProfileItemControl();
                pit.Image = Image.FromFile(Program.dataset.Get_Resurs_SUB(subcategory[i]));
                pit.Text = subcategory[i].ToString();
                pit.Tag = subcategory[i].ToString();
                pit.Click += pit_Click;
                tableLayoutPanel1.Controls.Add(pit);
            }
        
        }

    }
}
