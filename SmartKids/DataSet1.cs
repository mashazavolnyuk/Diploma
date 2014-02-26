using System.Collections.Generic;
using System.Data;
using System.Linq;
using SmartKids.Enums;
using SmartKids.Properties;

namespace SmartKids
{
    public partial class DataSet1
    {
        public void SaveChanges()
        {
            AcceptChanges();
            WriteXml(Resources.dataBasePath);
        }


        internal List<string> Get_SUB_Cat_name()
        {
            return (from DataRow d in Subcategort.Rows select d[Subcategort.nameColumn].ToString()).ToList();
        }

        partial class CategotyDataTable
        {
        }

        partial class SubcategortDataTable
        {
        }

        partial class TasksDataTable
        {
        }

        #region Работа с левелами

        //ДОБАВИТЬ категорию
        internal void AddCategory(string name, string path)
        {
            DataRow row = Categoty.NewRow();
            row[Categoty.nameColumn] = name; // все данные в row - всегда типа object
            row[Categoty.imagePathColumn] = path;
            Categoty.Rows.Add(row);
            SaveChanges();
        }


        //ДОБАВИТЬ подкатегорию
        public void SubCategory(int category, string nameSubcat, string path)
        {
            DataRow row = Subcategort.NewRow();
            row[Subcategort.nameColumn] = nameSubcat;
            row[Subcategort.id_catColumn] = category;
            row[Subcategort.imagePathColumn] = path;
            Subcategort.Rows.Add(row);
            SaveChanges();
        }

        //получение id оталкиваясь от name 
        public int Search_ID_CAT(string name_cat)
        {
            int id = (from DataRow IT in Categoty.Rows
                where IT[Categoty.nameColumn] == name_cat
                select (int) IT[Categoty.cat_idColumn]).ToList()[0];
            return id;
        }

        //получение нахождения ресурсов оталкиваясь от name

        public string Search_IMAGE_CAT(string name_cat)
        {
            string name_resurs = (from DataRow IT in Categoty.Rows
                where IT[Categoty.nameColumn] == name_cat
                select (string) IT[Categoty.imagePathColumn]).ToList()[0];
            return name_resurs;
        }

        public void Add_Task(string Eng_word, string Rus_word, string Sub_name, string path)
        {
            DataRow row = Tasks.NewRow();
            row[Tasks.eng_wordColumn] = Eng_word;
            row[Tasks.rus_wordColumn] = Rus_word;
            int id = Get_ID_TASK(Sub_name);
            row[Tasks.sud_idColumn] = id;
            row[Tasks.imagePathColumn] = path;
        }


        private int Get_ID_TASK(string Sub_name)
        {
            int id = (from DataRow IT in Subcategort.Rows
                where IT[Subcategort.nameColumn] == Sub_name
                select (int) IT[Subcategort.sub_idColumn]).ToList()[0];
            return id;
        }

        internal List<string> GetCat_name()
        {
            return (from DataRow d in Categoty.Rows select d[Categoty.nameColumn].ToString()).ToList();
        }


        internal List<int> GetCat_ID()
        {
            return (from DataRow d in Categoty.Rows select (int) d[Categoty.cat_idColumn]).ToList();
        }


        internal string Get_Resurs(int p)
        {
            return
                (from DataRow d in Categoty.Rows
                    where (int) d[Categoty.cat_idColumn] == p
                    select d[Categoty.imagePathColumn].ToString()).ToList()[0];
        }

        #endregion

        #region Работа с юзерами

        public bool New_User(string Name, string Pass, Gender g)
        {
            List<string> rows = (from DataRow U in Users.Rows
                where U[Users.user_nameColumn].ToString() == Name
                select U[Users.user_nameColumn].ToString()).ToList();
            if (rows.Contains(Name))
                return false;
            DataRow newUser = Users.NewRow();
            newUser[Users.user_nameColumn] = Name;
            newUser[Users.passColumn] = Pass;
            newUser[Users.GenderColumn] = g;
            Users.Rows.Add(newUser);
            SaveChanges();
            return true;
        }


        private int Search_ID_User(string name_user)
        {
            int id = (from DataRow IT in Users.Rows
                where IT[Users.user_nameColumn] == name_user
                select (int) IT[Users.user_idColumn]).ToList()[0];
            return id;
        }

        internal void DeleteUser(int id)
        {
            //пишем запрос в котором получаем все записи с user_id == нашему удаляемому ID 
            DataRow temp =
                (from DataRow row in Users.Rows where (int) row[Users.user_idColumn] == id select row).ToList()[0];

            Users.Rows.Remove(temp);
            SaveChanges();
        }

        #endregion

        #region Проверка авторизации

        internal bool Open_YES(string Name_user, string Pass)
        {
            List<string> list = (from DataRow name in Users.Rows
                where name[Users.user_nameColumn].ToString() == Name_user
                select name[Users.passColumn].ToString()).ToList();

            if (list.Count != 0)
            {
                string s = list[0];
                if (s == Pass)
                    return true;
                return false;
            }

            return false;
        }

        #endregion
    }
}