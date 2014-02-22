using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKids
{
    public class Сategory
    {
        private bool open;//открытость категории.for User
        private string name;//название
        private int coin;//стоимость
        public string Picter;
        List<int> subcategory = new List<int>();//список подкатегорий..id
        public Сategory(string Name,string picter) {
         this.name = Name;
         this.Picter = picter;
        }
    
    }
}
