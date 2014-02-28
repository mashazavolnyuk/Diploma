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
    public partial class TEST : Win8Form
    {
        List<Task> my_task = new List<Task>();
        public TEST(List<Task> task)
        {
            InitializeComponent();
            my_task = task;
        }

        private void Start_Show() { 
        

        
        
        
        }

        private void TEST_Load(object sender, EventArgs e)
        {


        }

    }

}
