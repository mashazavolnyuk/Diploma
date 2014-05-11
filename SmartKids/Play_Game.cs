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
    public partial class Play_Game : Win8Form
    {

        private string name;//юзеру,которому засчитываем очки
        int coin = 0;//количество очков
        List<Task> task = new List<Task>();//все задания
        Random My_Random = new Random(); 
        int begin = 0;
        int end;
        int curent_word;
        

        public Play_Game(string Name)
        {
            InitializeComponent();
            this.name = Name;
            Load_Task();
            Start_Game();
        }

        private void Load_Task() { 
 
          task = Program.dataset.Load_Task();
          end = task.Count;
        }

        ///TODO 
        ///КАК БЫ ДПИСАТЬ НАДО)))
        //по таймеру стартуем

        private void Start_Game()
        {
            List<PictureBox> pic = new List<PictureBox>();
            pic.Add(pictureBox1);
            pic.Add(pictureBox2);
            pic.Add(pictureBox3);
            pic.Add(pictureBox4);
            int count = pic.Count;


            curent_word = My_Random.Next(coin, end);
            label1.Text = task[curent_word].eng_word;
            int random = My_Random.Next(0, count);
            pic[random].Image = Image.FromFile(task[curent_word].image);



        }



    }
}
