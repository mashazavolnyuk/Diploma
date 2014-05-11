using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartKids;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeleteCategoryTest()
        {
            Console.WriteLine(@"=========== Before deletion ==============");
            DataSet1 dataset = new DataSet1();
            string path = @"C:\Users\Natalya\Pictures\Screenshots\Снимок экрана (1).png";
            dataset.AddCategory("one", path);

            dataset.AddCategory("two", path);

            dataset.AddSubCategory(0, "one", path);
            dataset.AddSubCategory(0, "two",path);
            dataset.AddSubCategory(0, "three", path);
            dataset.AddSubCategory(0, "fur", path);
            dataset.AddSubCategory(0, "five", path);

            dataset.AddSubCategory(1, "one", path);
            dataset.AddSubCategory(1, "two", path);
            dataset.AddSubCategory(1, "three", path);
            dataset.AddSubCategory(1, "fur", path);
            dataset.AddSubCategory(1, "five", path);


            dataset.AddTask("lol", "loool", 0, path);
            dataset.AddTask("lol", "loool", 0, path);
            dataset.AddTask("lol", "loool", 0, path);
            dataset.AddTask("lol", "loool", 1, path);
            dataset.AddTask("lol", "loool", 1, path);
            dataset.AddTask("lol", "loool", 1, path);
            dataset.AddTask("lol", "loool", 2, path);
            dataset.AddTask("lol", "loool", 3, path);
            dataset.AddTask("lol", "loool", 4, path);


            ShowDataset(dataset);

            dataset.DeleteCategory(0);

            Console.WriteLine(@"=========== After deletion ==============");

            ShowDataset(dataset);


            ShowDataSet2(dataset);

        }

        private void ShowDataSet2(DataSet1 dataset)
        {
            foreach (DataSet1.CategotyRow row in dataset.Categoty.Rows)
            {
                Console.WriteLine(row.name);

            }
            foreach (DataSet1.SubcategortRow subcategortRow in dataset.Subcategort.Rows)
            {
                Console.WriteLine("\t" + subcategortRow.name);
            }

            foreach (DataSet1.TasksRow tasksRow in dataset.Tasks.Rows)
            {
                Console.WriteLine("\t\t" + tasksRow.id_task);
            }
        }

        private static void ShowDataset(DataSet1 dataset)
        {
            foreach (DataSet1.CategotyRow row in dataset.Categoty.Rows)
            {
                Console.WriteLine(row.name);
                foreach (DataSet1.SubcategortRow subcategortRow in row.GetSubcategortRows())
                {
                    Console.WriteLine("\t" + subcategortRow.name);

                    foreach (DataSet1.TasksRow tasksRow in subcategortRow.GetTasksRows())
                    {
                        Console.WriteLine("\t\t" + tasksRow.id_task);
                    }
                }
            }
        }


    }
}
