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
    public partial class All_category : Win8Form
    {
        List<string> All_categ = new List<string>();
        public All_category()
        {
            InitializeComponent();
            All_categ = Program.dataset.LoadAllCategories();
            Show_categ(All_categ);

        }
        public void Show_categ(List<string> list){

            listBox1.DataSource = list;
        
        
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem!= null)
            {
                string name = listBox1.SelectedItem.ToString();
                int id = Program.dataset.GetCategoryIdByName(name);
                Program.dataset.DeleteCategory(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.dataset.DeleteAllCategory();
        }


    }
}
