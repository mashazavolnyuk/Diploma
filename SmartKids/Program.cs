using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SmartKids
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static DataSet1 dataset;

        [STAThread]
        static void Main()
        {
            dataset = new DataSet1();

            if(!File.Exists(Properties.Resources.dataBasePath))
                dataset.WriteXml(Properties.Resources.dataBasePath);
            else
                dataset.ReadXml(Properties.Resources.dataBasePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new START());
        }
    }
}
