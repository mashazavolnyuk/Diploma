using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace SmartKids
{


    public partial class DataSet1
    {
        partial class TasksDataTable
        {
        }
    
        partial class CategotyDataTable
        {
        }
    
        public bool AddUser(string name)
        {
            List<DataRow> rows = (from DataRow row in Users.Rows where row[Users.user_nameColumn].ToString() == name select row).ToList(); 
            // хвучит это так - ИЗ списка строк в таблице с пользователями ГДЕ имя пользователя в таблице совпадает с именем нового пользователя ВЫБИРАЕМ строку и полученный обыект от такого запроса преобразовываем в список строк
            
            if (rows.Count == 0) //если строк с таким именем как у нового пользователя не найдено
            {
                //добавляем пользователя в БД

            DataRow newUser = Users.NewRow();
            newUser[Users.user_nameColumn] = name;
            newUser["points"] = 0;
           

            Users.Rows.Add(newUser);
            this.AcceptChanges();

            //сохранять - если данных не много, то так  удобнее :
            this.WriteXml("dataBase.xml");
            return true;

            //это мы добавляем в базу пользователя
            }

            return false;
        }

        // все изменения в БД нужно сохранять в файл, т.е. после любй операции , будь то добавлени/удаление/редактрование - нужно производитьзапись в xml файл, иначе при запуске читать будет из файла, а если изменений там нет то стственно все останется по старому. 
        //  данном случае необходимо обработать событие удаления запсис в datagidview  и сохранить это дело в файл

        internal void DeleteUser(int id)
        {
            DataRow temp = (from DataRow row in Users.Rows where (int)row[Users.user_idColumn] == id select row).ToList()[0];
            //пишем запрос в котором получаем все записи с user_id == нашему удаляемому ID - 
            /// плучили записи, но мы то знаем, что user_id уникальный и другой таой просто нет,
            /// // поэтому м в наглую берем нуевой элемент полученного списка
            /// // скажу больше - там по идее всегда один элмент будет, и помещаем эго в отдельнуюю переенную,
            /// и теперь эту переменную отдаем в качестве параметра для даленияиз БД
            /// и сохраняем измеения
            /// воть...
            
            Users.Rows.Remove(temp);
            this.AcceptChanges();
            this.WriteXml("dataBase.xml");
        }
    }
}