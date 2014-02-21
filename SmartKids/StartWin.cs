using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartKids
{
    public partial class StartWin : Form
    {

        public StartWin()
        {
            InitializeComponent();
            
        }

        private void StartWin_Load(object sender, EventArgs e)
        {
            dataSet1.ReadXml("dataBase.xml");//так мало кода..чудесно..
            //в данном случае впапке с exeшиком
            //блин...мне удобно было деать разбор загрузки при подлюченном режиме...
            //да сохраняй куда угодно этот файл
            //всмысле когда надо загрузить пользователей..там проверить на одинаковость имен..в таком плане
            //тогда лучше при добавлении пользователей проверяять чтоб таких не существовало - щас окажу

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty)
            {
                if (!dataSet1.AddUser(textBox1.Text))
                {
                    MessageBox.Show("User already exist!");
                }
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (DataRow item in dataSet1.Users.Rows)
            {
                listBox1.Items.Add(item["user_name"].ToString() + " - " + item["points"].ToString());
            }

            //как то так :) 
            // можно еще datagridview использоваь
            //вот  так вроде норм :)
            //а в грувшке оно удаляет автоматически за ним?
            //гдее???7datagriew//
            //    ааа, ну да - по идее любое измение в бд, вносится в превьюшку
            //       забыла загрузку показать
            //загрузилос :)а ще раз??где ты написала а то быстро как то..

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //получаем id удаляемой записи
            int id = (int)e.Row.Cells[0].Value; // в первой ячейке датагрда находится индекс записи

            dataSet1.DeleteUser(id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_category a = new Add_category();
            a.Show();
        }
    }
}
