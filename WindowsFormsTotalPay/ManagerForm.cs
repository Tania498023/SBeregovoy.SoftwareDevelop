using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTotalPay
{
    public partial class ManagerForm : Form
    {
        private string roleform;
       

        public ManagerForm()
        {
            
        }

        public ManagerForm(string roleform)
        {
            InitializeComponent();
            this.roleform = roleform;
            //добавить лейбл на форму и присвоить ему полученную роль
            if (roleform == "manager")
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox6.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                listBox1.Visible = true;
                LoadUsers();
            }

            if (roleform == "freelanser")
            {
                
                textBox2.Visible = true;
                textBox5.Visible = true;
                button2.Visible = true;
                button5.Visible = true;

            }
        }

        private  void LoadUsers()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmd = $"SELECT [Name],[Role] FROM[Beregovoj].[dbo].[users] ";
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            foreach (DataRow row in table.Rows)
            {
                string r = "";
                int r1 = 0;
                foreach (DataColumn column in table.Columns)
                {
             
                        roleform = row[column].ToString();
                        
                        r += roleform + ",";

                        r1++;
                        if(r1 == 2)
                            listBox1.Items.Add(r);
         
                }

            }
            
            
        }
        //сформировать запрос с полученными переменными и выполнить запрос к БД с Инсерт для записи данных
        //очистить ЛистБокс
        //загрузить из БД новый набор данных и добавить его в ТекстБокс
        private void button1_Click(object sender, EventArgs e)
        {
            string inputName= textBox1.Text;
            string inputRole = textBox6.Text;

            SqlConnection connection = new SqlConnection(@"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True"); // создание подключения
            connection.Open();

            

            SqlCommand insertCommand = connection.CreateCommand(); // создание команды на вставку данных
            insertCommand.CommandText = $"INSERT INTO users ([Name],[Role]) VALUES ('{inputName}', '{inputRole}')";

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            connection.Close();
            
            listBox1.Items.Clear();
            LoadUsers();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            var del = listBox1.SelectedItem.ToString().Split(',')[0];
            SqlConnection connection = new SqlConnection(@"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True"); // создание подключения
            connection.Open();

            SqlCommand insertCommand = connection.CreateCommand(); 
            insertCommand.CommandText = $"Delete  users where [Name] = '{del}'";//подготовка запроса

            int rowAffected = insertCommand.ExecuteNonQuery(); //выполнили запрос
            connection.Close();

            listBox1.Items.Clear();
            LoadUsers();
        }


    }
}
