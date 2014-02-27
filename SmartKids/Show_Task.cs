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

        public Show_Task(int subcat)
        {
            InitializeComponent();
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

            Show_TASK();

        }
        private void Show_TASK() {

            for (int i = 0; i < task.Count; i++)
            {
               // pictureBox1.Image = Image.FromFile(task[i].image);
                label1.Text = task[i].eng_word;
                label2.Text = task[i].rus_word;
            }
        }
    }
}
