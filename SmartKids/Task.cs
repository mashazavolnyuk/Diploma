using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartKids
{
    public class Task
    {
       public string image;
       public string eng_word;
       public string rus_word;
        private int sub;

        public Task(string ENG,string RUS,string Image) {
            this.eng_word = ENG;
            this.rus_word = RUS;
            this.image = Image;
        }

    }
}
