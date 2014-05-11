using System.Collections.Generic;
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


        internal List<string> GetSubCategoryNames()
        {
            return (from SubcategortRow d in Subcategort.Rows select d.name).ToList();
        }

        internal List<int> GetSubCategoriesByCategoryId(int categoryId)
        {
            return (from SubcategortRow d in Subcategort.Rows
                where d.id_cat == categoryId
                select d.sub_id).ToList();
        }

        internal string GetImageBySubCategoryId(int subCategoryId)
        {
            List<string> images = (from SubcategortRow d in Subcategort.Rows
                where d.sub_id == subCategoryId
                select d.imagePath).ToList();
            if (images.Count > 0)
                return
                    images[0];
            return "";
        }

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

        //получение id оталкиваясь от name 
        public int GetCategoryIdByName(string name)
        {
            List<CategotyRow> r = (from CategotyRow item in Categoty.Rows where item.name == name select item).ToList();

            if (r.Count != 0)
                return r[0].cat_id;

            return -1;
        }

        public int GetSubCategoryIdByName(string name)
        {
            List<SubcategortRow> r =
                (from SubcategortRow item in Subcategort.Rows where item.name == name select item).ToList();

            if (r.Count != 0)
                return r[0].sub_id;

            return -1;
        }

        //УДАЛИТЬ ВСЕ КАТЕГОРИИ
        internal void DeleteAllCategory()
        {
            for (int i = Categoty.Rows.Count - 1; i >= 0; i--)
            {
                Categoty.Rows[i].Delete();
            }
            SaveChanges();
        }


        //ФОТО ЮЗЕРА
        internal UsersRow GetUserByName(string name)
        {
            int id = GetUserIdByName(name);
            List<UsersRow> collection = (from UsersRow user in Users.Rows
                where user.user_id == id
                select user).ToList();


            if (collection.Count != 0)
                return collection.First();
            return null;
        }


        //имя категории по индексу
        internal string GetCategoryNameById(int categoryId)
        {
            var names = (from CategotyRow category in Categoty.Rows
                where category.cat_id == categoryId
                select category.name).ToList();
            if (names.Count > 0)
                return names[0];
            return "";
        }

        #region загрузки для TASK-класса

        internal List<int> GetTasksIdBySubCategoryId(int subCategoryId)
        {
            return (from TasksRow d in Tasks.Rows
                where d.sud_id == subCategoryId
                select d.id_task).ToList();
        }

        internal string GetEnglishWordByTaskId(int id)
        {
            return Tasks.FindByid_task(id).eng_word;
        }

        internal string GetRussianWordByTaskId(int id)
        {
            return Tasks.FindByid_task(id).rus_word;
        }

        internal string GetImagePathByTaskId(int id)
        {
            return Tasks.FindByid_task(id).imagePath;
        }

        //ВЕРНУТЬ Все Задания
        internal List<Task> LoadTasks()
        {
            List<TasksRow> tasks = (from TasksRow d in Tasks.Rows
                select d).ToList();
            var list = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                list.Add(new Task(tasks[i].eng_word, tasks[i].rus_word, tasks[i].imagePath));
            }

            return list;
        }

        #endregion

        #region Работа с уровнями

        //ДОБАВИТЬ категорию
        public void AddCategory(string name, string path)
        {
            CategotyRow row = Categoty.NewCategotyRow();
            row.name = name; // все данные в row - всегда типа object
            row.imagePath = path;
            Categoty.Rows.Add(row);
            SaveChanges();
        }


        //ДОБАВИТЬ подкатегорию
        public void AddSubCategory(int category, string nameSubcat, string path)
        {
            SubcategortRow row = Subcategort.NewSubcategortRow();
            row.name = nameSubcat;
            row.id_cat = category;
            row.imagePath = path;
            Subcategort.Rows.Add(row);
            SaveChanges();
        }


        //ЗАГРУЗКА ВСЕХ КАТЕГОРИЙ

        public List<string> LoadAllCategories()
        {
            return (from CategotyRow category in Categoty.Rows
                select category.name).ToList();
        }

        //ЗАГРУЗКА ВСЕХ ПОДКАТЕГОРИЙ
        public List<string> LoadSubCategories()
        {
            return (from SubcategortRow category in Subcategort.Rows
                select category.name).ToList();
        }

        //получение нахождения ресурсов оталкиваясь от name
        public string GetImageByCategoryName(string categoryName)
        {
            List<string> rows = (from CategotyRow row in Categoty.Rows
                where row.name == categoryName
                select row.imagePath).ToList();
            if (rows.Count > 0)
                return rows[0];

            return "";
        }

        public void AddTask(string englishWord, string russianWord, string subCategoryName, string imagePath)
        {
            TasksRow row = Tasks.NewTasksRow();
            row.eng_word = englishWord;
            row.rus_word = russianWord;
            int id = GetCategoryIdByName(subCategoryName);
            row.sud_id = id;
            row.imagePath = imagePath;
            Tasks.Rows.Add(row);
            SaveChanges();
        }

        public void AddTask(string englishWord, string russianWord, int subCategoryId, string imagePath)
        {
            TasksRow row = Tasks.NewTasksRow();
            row.eng_word = englishWord;
            row.rus_word = russianWord;
            row.sud_id = subCategoryId;
            row.imagePath = imagePath;
            Tasks.Rows.Add(row);
            SaveChanges();
        }


        internal List<string> GetAllCategoriesNames()
        {
            return (from CategotyRow d in Categoty.Rows select d.name).ToList();
        }


        internal List<int> GetAllCategoriesIds()
        {
            return (from CategotyRow d in Categoty.Rows select d.cat_id).ToList();
        }


        internal string GetImagePathByCategoryId(int id)
        {
            return Categoty.FindBycat_id(id).imagePath;
        }

        #endregion

        #region Работа с юзерами

        public bool NewUser(string name, string password, Gender gender, string photoPath = null)
        {
            List<string> rows = (from UsersRow user in Users.Rows
                where user.user_name == name
                select user.user_name).ToList();
            if (rows.Count > 0)
                return false;

            UsersRow newUser = Users.NewUsersRow();
            newUser.user_name = name;
            newUser.pass = password;
            newUser.Gender = gender.ToString();
            newUser.Photo = photoPath;


            Users.Rows.Add(newUser);
            SaveChanges();
            return true;
        }


        private int GetUserIdByName(string userName)
        {
            List<int> id = (from UsersRow user in Users.Rows
                where user.user_name == userName
                select user.user_id).ToList();
            if (id.Count > 0)
                return id[0];
            return -1;
        }

        internal void DeleteUser(int id)
        {
            //пишем запрос в котором получаем все записи с user_id == нашему удаляемому ID 
            List<UsersRow> temp =
                (from UsersRow row in Users.Rows where row.user_id == id select row).ToList();

            temp.First().Delete();
            SaveChanges();
        }

        #endregion

        #region Проверка авторизации

        internal bool Authorization(string username, string password)
        {
            List<string> list = (from UsersRow name in Users.Rows
                where name.user_name == username
                select name.pass).ToList();

            if (list.Count != 0)
            {
                string s = list[0];
                if (s == password)
                    return true;
                return false;
            }

            return false;
        }

        #endregion
    }
}