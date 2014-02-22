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
    public partial class Add_subcategory : Form
    {


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






    }
}
