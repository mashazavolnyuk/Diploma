using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKids
{
    public class Сategory
    {
       
      public string name;//название
        public string Picter;
        List<int> subcategory = new List<int>();//список подкатегорий..id
        int index;//индекс категории

        public Сategory(string Name,string picter,int Index) {
         this.name = Name;
         this.Picter = picter;
         this.index = Index;

        }
    
    }
}
