using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;

using Word = Microsoft.Office.Interop.Word;

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

        private void Load_ID_TASK(int Subcategory)
        {
            task_id = Program.dataset.GetTasksIdBySubCategoryId(Subcat);
            Load_TASK(task_id);
        }


        private void Load_TASK(List<int> temp_id)
        {

            for (int i = 0; i < temp_id.Count; i++)
            {
                string eng = Program.dataset.GetEnglishWordByTaskId(temp_id[i]);
                string rus = Program.dataset.GetRussianWordByTaskId(temp_id[i]);
                string im = Program.dataset.GetImagePathByTaskId(temp_id[i]);
                task.Add(new Task(eng, rus, im));
            }

            pictureBox1.Image = Image.FromFile(task[currentId].image.ToString());
            label1.Text = task[currentId].eng_word;
            label2.Text = task[currentId].rus_word;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentId++;

            if (currentId >= task.Count)
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

            if (currentId < 0)
            {
                currentId = task.Count - 1;
            }

            pictureBox1.Image = Image.FromFile(task[currentId].image.ToString());
            label1.Text = task[currentId].eng_word;
            label2.Text = task[currentId].rus_word;

        }



        private void Play_Task()
        {
            currentId++;

            if (currentId >= task.Count)
            {
                currentId = 0;
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
            timer1.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TEST My_Task = new TEST(task);
            My_Task.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Play_Task();
        }



        private void Create_Document()
        {

            try { 
            Word._Application oWord;
            Word._Document oDoc; 

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            Document document = new Document();
            oWord = new Word.Application();
            oWord.Visible = true;

            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            Word.Paragraph oPara2;
           
            oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara2.Format.LineSpacing = 2;
            oPara2.Range.Text = "SMART KIDS" + "\n" + 
            "______________________________________";


            for (int i = 0; i < task.Count; i++) {

            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "Русское название" + "-"+ task[i].rus_word + "\n" 

                + "Английское название"+" "+ task[i].eng_word+"\n"

                +"____________________________________";
                  
            oPara1.Range.InsertParagraphAfter();

            oPara1.Format.SpaceAfter = 24;  
 
            }
            }
            catch(Exception e)
            {

                MessageBox.Show("Ошибка создания документа. Возможно у Вас отсутсвует необходимое для этого приложение");
            
            }

           



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Create_Document();


        }




    }
}

