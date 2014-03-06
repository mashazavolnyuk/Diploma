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
        List<string> test = new List<string>();//слова которые следует повторить

        int count = 0;

        public TEST(List<Task> task)
        {
            InitializeComponent();
            my_task = task;
            
        }


        private void Start_Show() {

            count++;
            if (count == my_task.Count)
            {
                MessageBox.Show("конец");
                count = 0;
                listBox1.DataSource = test;
                test.Clear();

            }
        pictureBox1.Image = Image.FromFile(my_task[count].image.ToString());
  
        }

        private void TEST_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=my_task[count].eng_word)
            test.Add(my_task[count].eng_word);
            Start_Show();
            
        }

    }

}
