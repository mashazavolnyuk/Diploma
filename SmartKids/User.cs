﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartKids.Enums;

namespace SmartKids
{
    class User
    {


        private int id;
        private string name;//имя
        private string pass;//пароль
        private Gender s; //пол
        private int coin;//количество монет
        private List<int> award = new List<int>();//список наград..id

        public User(string Name, string Pass, Gender S) {
            this.name = Name;
            this.pass = Pass;
            this.s = S;
        }

        public void AddCoin(int number) {// прибавить золото
            coin += number;
        }

       public int CounCoin(){//показать количество монет
           return coin;
       }


       public void TakeCoin(int number) { //отнять золото
           coin -= number;
       }
       


    }
}
