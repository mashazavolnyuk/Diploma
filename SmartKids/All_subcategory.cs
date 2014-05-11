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
    public partial class All_subcategory : Win8Form
    {   


        List<string> All_scateg = new List<string>();
        public All_subcategory()
        {
            InitializeComponent();
            All_scateg = Program.dataset.LoadSubCategories();
            Show_subcat();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Show_subcat() {
            listBox1.DataSource = All_scateg;
        
        
        
        }



    }
}
