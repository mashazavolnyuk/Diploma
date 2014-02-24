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
    public partial class Show_subcat : Form
    {

        private int Cat;
        public Show_subcat(int cat)
        {
            InitializeComponent();
            this.Cat = cat;
        }


        private void Show_subcat_Load(object sender, EventArgs e)
        {

            label1.Text = Cat.ToString();



        }
    }
}
