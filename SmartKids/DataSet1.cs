﻿using System.Collections.Generic;
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

        #region Работа с уровнями

        //ДОБАВИТЬ категорию
        public void AddCategory(string name, string path)
        {
            DataRow row = Categoty.NewRow();
            row[Categoty.nameColumn] = name; // все данные в row - всегда типа object
            row[Categoty.imagePathColumn] = path;
            Categoty.Rows.Add(row);
            SaveChanges();
        }


        //ДОБАВИТЬ подкатегорию
        public void AddSubCategory(int category, string nameSubcat, string path)
        {
            DataRow row = Subcategort.NewRow();
            row[Subcategort.nameColumn] = nameSubcat;
            row[Subcategort.id_catColumn] = category;
            row[Subcategort.imagePathColumn] = path;
            Subcategort.Rows.Add(row);
            SaveChanges();
        }


        //ЗАГРУЗКА ВСЕХ КАТЕГОРИЙ

        public List<string> Load_ALLCATEG() { 
        
        List<string> all=(from DataRow AC in Categoty.Rows
                          select AC[Categoty.nameColumn].ToString()).ToList();
        return all;
  
        }

        //ЗАГРУЗКА ВСЕХ ПОДКАТЕГОРИЙ
        public List<string> Load_SUBCAT() {

        List<string> all = (from DataRow AC in Subcategort.Rows
                            select AC[Subcategort.nameColumn].ToString()).ToList();
         return all;
        }


        //получение id оталкиваясь от name 
        public int Search_ID_CAT(string name_cat)
        {
            int id = (from DataRow IT in Categoty.Rows
                      where IT[Categoty.nameColumn] == name_cat
                      select (int)IT[Categoty.cat_idColumn]).ToList()[0];
            return id;
        }

        //получение нахождения ресурсов оталкиваясь от name

        public string Search_IMAGE_CAT(string name_cat)
        {
            string name_resurs = (from DataRow IT in Categoty.Rows
                                  where IT[Categoty.nameColumn] == name_cat
                                  select (string)IT[Categoty.imagePathColumn]).ToList()[0];
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
            Tasks.Rows.Add(row);
            SaveChanges();
        }

        public void Add_Task(string Eng_word, string Rus_word, int Sub_id, string path)
        {
            DataRow row = Tasks.NewRow();
            row[Tasks.eng_wordColumn] = Eng_word;
            row[Tasks.rus_wordColumn] = Rus_word;
            row[Tasks.sud_idColumn] = Sub_id;
            row[Tasks.imagePathColumn] = path;
            Tasks.Rows.Add(row);
            SaveChanges();
        }


        private int Get_ID_TASK(string Sub_name)
        {
            int id = (from DataRow IT in Subcategort.Rows
                      where IT[Subcategort.nameColumn] == Sub_name
                      select (int)IT[Subcategort.sub_idColumn]).ToList()[0];
            return id;
        }

        internal List<string> GetCat_name()
        {
            return (from DataRow d in Categoty.Rows select d[Categoty.nameColumn].ToString()).ToList();
        }


        internal List<int> GetCat_ID()
        {
            return (from DataRow d in Categoty.Rows select (int)d[Categoty.cat_idColumn]).ToList();
        }


        internal string Get_Resurs(int p)
        {
            return
                (from DataRow d in Categoty.Rows
                 where (int)d[Categoty.cat_idColumn] == p
                 select d[Categoty.imagePathColumn].ToString()).ToList()[0];
        }




        #endregion

        #region Работа с юзерами

        public bool New_User(string Name, string Pass, Gender g, string Photo)
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
            newUser[Users.PhotoColumn] = Photo;


            Users.Rows.Add(newUser);
            SaveChanges();
            return true;
        }


        private int Search_ID_User(string name_user)
        {
            int id = (from DataRow IT in Users.Rows
                      where IT[Users.user_nameColumn] == name_user
                      select (int)IT[Users.user_idColumn]).ToList()[0];
            return id;
        }

        internal void DeleteUser(int id)
        {
            //пишем запрос в котором получаем все записи с user_id == нашему удаляемому ID 
            DataRow temp =
                (from DataRow row in Users.Rows where (int)row[Users.user_idColumn] == id select row).ToList()[0];

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

        internal List<int> Load_SUBCAT(int Category)
        {

            return (from DataRow d in Subcategort.Rows
                    where (int)d[Subcategort.id_catColumn] == Category
                    select (int)d[Subcategort.sub_idColumn]).ToList();
        }

        internal string Get_Resurs_SUB(int p)
        {
            return
                (from DataRow d in Subcategort.Rows
                 where (int)d[Subcategort.sub_idColumn] == p
                 select d[Subcategort.imagePathColumn].ToString()).ToList()[0];

        }

        #region загрузки для TASK-класса

        internal List<int> LOAD_ID_TASK(int Subcat)
        {
            return (from DataRow d in Tasks.Rows
                    where (int)d[Tasks.sud_idColumn] == Subcat
                    select (int)d[Tasks.id_taskColumn]).ToList();
        }

        internal string Get_ENG(int p)
        {
            return (from DataRow d in Tasks.Rows
                    where (int)d[Tasks.id_taskColumn] == p
                    select d[Tasks.eng_wordColumn].ToString()).ToList()[0];

        }

        internal string Get_RUS(int p)
        {
            return (from DataRow d in Tasks.Rows
                    where (int)d[Tasks.id_taskColumn] == p
                    select d[Tasks.rus_wordColumn].ToString()).ToList()[0];
        }

        internal string Get_res_image(int p)
        {
            return (from DataRow d in Tasks.Rows
                    where (int)d[Tasks.id_taskColumn] == p
                    select d[Tasks.imagePathColumn].ToString()).ToList()[0];

        }

        //ВЕРНУТЬ Все Задания
        internal List<Task> Load_Task() {

            List<TasksRow> tasks = (from TasksRow d in Tasks.Rows
                                    select d).ToList();
            List<Task> list = new List<Task>();
            for (int i = 0; i < tasks.Count; i++) {
                list.Add(new Task(tasks[i].eng_word, tasks[i].rus_word, tasks[i].imagePath));
            }
             
            return list;
        }


        #endregion

        public void DeleteTask(int id)
        {
            Tasks.Rows.Find(id).Delete();
            SaveChanges();
        }

        public void DeleteSubCategory(int id)
        {
            Subcategort.Rows.Find(id).Delete();
            SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Categoty.FindBycat_id(id).Delete();
            SaveChanges();
        }

        internal int GetCategoryIdByName(string name)
        {
            List<CategotyRow> r = (from CategotyRow item in Categoty.Rows where item.name == name select item).ToList();

            if (r.Count != 0)
                return r[0].cat_id;

            return -1;
        }
        //УДАЛИТЬ ВСЕ КАТЕГОРИИ
        internal void DeleteAllCategory()
        {
            for (int i = Categoty.Rows.Count-1; i >= 0; i--)
            {
                Categoty.Rows[i].Delete();
            }
            SaveChanges();
        }


        //ФОТО ЮЗЕРА
        internal string GetPhopo_USER(string Name)
        {
            int id = Get_Id_USER(Name);
            return (from DataRow IT in Users.Rows
                     where (int)IT[Users.user_idColumn]==id
                     select IT[Users.PhotoColumn].ToString()).ToList()[0];
                        
                        
                        
           
                      
        }
        private int Get_Id_USER(string Name){

        return (from DataRow IT in Users.Rows
                    where (string)IT[Users.user_nameColumn] == Name
                    select (int)IT[Users.user_idColumn]).ToList()[0];
        
        
        }


        //имя категории по индексу
        internal string Get_name_category(int p)
        {
            return (from DataRow IT in Categoty.Rows
                    where (int)IT[Categoty.cat_idColumn] == p
                    select (string)IT[Categoty.nameColumn]).ToList()[0];
        }         
        }
    }
