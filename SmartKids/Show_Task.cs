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
    public partial class Show_Task : Win8Form
    {
        private int Subcat;
        List<int> task_id = new List<int>();

        List<Task> task = new List<Task>();
        int currentId;

        public Show_Task(int subcat)
        {
            InitializeComponent();
            currentId = 0;


            this.Subcat = subcat;
            Load_ID_TASK(Subcat);

        }

        private void Load_ID_TASK(int Subcategory) {
            task_id = Program.dataset.LOAD_ID_TASK(Subcat);
            Load_TASK(task_id);
        }

        private void Load_TASK(List<int> temp_id) {

            for (int i = 0; i < temp_id.Count; i++)
            {
                string eng = Program.dataset.Get_ENG(temp_id[i]);
                string rus = Program.dataset.Get_RUS(temp_id[i]);
                string im = Program.dataset.Get_res_image(temp_id[i]);
                task.Add(new Task(eng,rus,im));
            }

            pictureBox1.Image = Image.FromFile(task[currentId].image.ToString());
            label1.Text = task[currentId].eng_word;
            label2.Text = task[currentId].rus_word;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentId++;

            if(currentId >= task.Count)
            {
                currentId = 0;
            }

            pictureBox1.Image = Image.FromFile(task[currentId].image.ToString());
            label1.Text = task[currentId].eng_word;
            label2.Text = task[currentId].rus_word;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentId--;

            if(currentId < 0)
            {
                currentId = task.Count-1;
            }

            pictureBox1.Image = Image.FromFile(task[currentId].image.ToString());
            label1.Text = task[currentId].eng_word;
            label2.Text = task[currentId].rus_word;

        }

        private void Show_Task_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TEST My_Task = new TEST(task);
            My_Task.Show();
        }
        }
    }

