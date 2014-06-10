using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Office.Interop.Word;
using Timer = System.Windows.Forms.Timer;

namespace SmartKids
{
    public partial class Play_Game : Win8Form
    {
        List<PictureBox> pictures = new List<PictureBox>();
        private Timer timer;
        Stopwatch gametime = new Stopwatch();
        Timer gametimer = new Timer();

        int coin = 0;//количество очков
        List<Task> task = new List<Task>();//все задания
        private List<int> usedWords;
        Random My_Random = new Random();
        int begin = 0;
        int end;
        int curent_word;


        public Play_Game()
        {
            InitializeComponent();
            timer = new Timer() { Interval = 5000 };
            task = Program.dataset.LoadTasks();

            if (task.Count < 4)
                MessageBox.Show("Не достаточно данных для игрового процесса");

            pictureBox1.Click += pictureBox_Click;
            pictureBox2.Click += pictureBox_Click;
            pictureBox3.Click += pictureBox_Click;
            pictureBox4.Click += pictureBox_Click;

            pictures.Add(pictureBox1);
            pictures.Add(pictureBox2);
            pictures.Add(pictureBox3);
            pictures.Add(pictureBox4);
        }

        void gametimer_Tick(object sender, EventArgs e)
        {
            label2.Text = gametime.Elapsed.ToString();
        }

        Stopwatch stopwatch = new Stopwatch();
        private void pictureBox_Click(object sender, EventArgs e)
        {
            timer.Stop();
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                if (pictureBox.Tag != null && pictureBox.Tag.ToString() == usedWords.Last().ToString())
                {
                    coin++;
                    pictureBox5.Image = Properties.Resources.ok;
                }
                else
                {
                    coin--;
                    pictureBox5.Image = Properties.Resources.no;
                }

                pictureBox5.Visible = true;
                stopwatch.Start();
                timer1.Start();
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            int taskId;
            do
            {
                taskId = My_Random.Next(0, task.Count);
            } while (usedWords.Contains(taskId) && usedWords.Count < task.Count);

            if (usedWords.Count == task.Count)
            {
                timer.Stop();
                gametime.Stop();
                gametimer.Stop();
                Program.CurrentUser.points += coin;
                if (Program.CurrentUser.points < 0)
                    Program.CurrentUser.points = 0;
                Program.dataset.SaveChanges();

                MessageBox.Show("Игра окончена. Вы набрали " + coin + " очков. Всего у вас " +
                                Program.CurrentUser.points + " очков. Потрачено времени: " + gametime.Elapsed.Hours + ":" + gametime.Elapsed.Minutes + ":" + gametime.Elapsed.Seconds);
                this.Close();

            }
            else
            {
                List<int> usedPictures = new List<int>();
                usedWords.Add(taskId);
                label1.Text = task[taskId].eng_word;

                int randomImage = My_Random.Next(0, 4);
                pictures[randomImage].Image = new Bitmap(task[taskId].image);
                pictures[randomImage].Tag = taskId;
                usedPictures.Add(taskId);


                for (int i = 0; i < 4; i++)
                {
                    if (i != randomImage)
                    {
                        int someId;
                        do
                        {
                            someId = My_Random.Next(0, 4);
                        } while (usedPictures.Contains(someId));
                        pictures[i].Image = new Bitmap(task[someId].image);
                        usedPictures.Add(someId);
                    }
                }
            }



        }



        private void Play_Game_Load(object sender, EventArgs e)
        {
            timer.Tick += timer_Tick;

            usedWords = new List<int>();
            timer.Start();
            timer_Tick(timer, new EventArgs());

            gametimer.Interval = 100;
            gametimer.Tick += gametimer_Tick;
            gametimer.Start();

            gametime.Start();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                pictureBox5.Visible = false;
                stopwatch.Stop();
                stopwatch.Reset();
                timer1.Stop();

                timer.Start();
                timer_Tick(timer, new EventArgs());
            }
        
    }


    }
}
