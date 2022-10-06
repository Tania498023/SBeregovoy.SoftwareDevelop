using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsTotalPay;

namespace WindowsFormsTotalPay
{
    public partial class ManagerForm : Form
    {
        private readonly string roleform;
        private string UserName;
       
        private string DbString = @"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True";

        
        public ManagerForm(string roles, string name)
        {
            InitializeComponent();
            roleform = roles;
            UserName = name;
           
            //добавить лейбл на форму и присвоить ему полученную роль
            if (roleform == "manager")
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label2.Visible = true;
                textBox7.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                listBox1.Visible = true;
                comboBoxRole.Visible = true;
                delButton.Visible = true;

                LoadRole();
            }

            if (roleform == "freelanser" || roleform == "employee")
            {
                
                textBox2.Visible = true;
                
                button2.Visible = true;
                

            }
            LoadUsers();
        }

        DataTable tableUsers = new DataTable();
        private  void LoadUsers()//загружаем имя пользователя(usera) в listBox1
        {
            DB db = new DB();
           
            SqlDataAdapter adapter = new SqlDataAdapter();
          //  [ID] из запроса не удаляем, используется дальше в коде
            string cmd = $"SELECT users.[ID],[Name],[Role] FROM [Beregovoj].[dbo].[UserRole] Right JOIN users ON users.IDRole = [UserRole].ID ";
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(tableUsers);
            
            foreach (DataRow row in tableUsers.Rows)//в первом цикле это первая строка
            {
                string us = "";
                int us1 = 0;
                string usn = "";
                foreach (DataColumn column in tableUsers.Columns)
                {

                    usn = row[column].ToString();
                        
                        us += usn + " ";

                        us1++;
                        if(us1 == 2)
                            listBox1.Items.Add(us);
         
                }

            }
            
            
        }
        private void LoadRole()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //  [ID] из запроса не удаляем, используется дальше в коде
            string cmd = $"SELECT [ID],[Role] FROM [Beregovoj].[dbo].[UserRole] ";
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());

            string role;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                string r = "";
                int r1 = 0;
                foreach (DataColumn column in table.Columns)
                {

                    role = row[column].ToString();

                    r += role + ",";

                    r1++;
                    if (r1 == 2)
                        comboBoxRole.Items.Add(r);

                }

            }


        }
        //сформировать запрос с полученными переменными и выполнить запрос к БД с Инсерт для записи данных
        //очистить ЛистБокс
        //загрузить из БД новый набор данных и добавить его в ТекстБокс
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Роль не выбрана!");
                return;
            }
            string inputName= textBox1.Text;
           

            var RoleString = comboBoxRole.SelectedItem.ToString().Split(',')[0];
            int RoleUser = Int32.Parse(RoleString);

            SqlConnection connection = new SqlConnection(@"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True"); // создание подключения
            connection.Open();

            

            SqlCommand insertCommand = connection.CreateCommand(); // создание команды на вставку данных
            insertCommand.CommandText = $"INSERT INTO users ([Name],[IDRole]) VALUES ('{inputName}', '{RoleUser}')";

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            connection.Close();
            
            listBox1.Items.Clear();
            LoadUsers();

            DialogeCheck();
        
        }

        

        private void delButton_Click(object sender, EventArgs e)
        {
            var del = listBox1.SelectedItem.ToString().Split(',')[0];
            SqlConnection connection = new SqlConnection(DbString); // создание подключения
            connection.Open();

            SqlCommand insertCommand = connection.CreateCommand(); 
            insertCommand.CommandText = $"Delete  users where [Name] = '{del}'";//подготовка запроса

            int rowAffected = insertCommand.ExecuteNonQuery(); //выполнили запрос
            connection.Close();

            listBox1.Items.Clear();
            LoadUsers();

        }
        DataTable table = new DataTable();
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadDataForGreed();
            dataGridView1.DataSource = table;//обновление dataGridView1 из таблицы SQL
        }

        private void LoadDataForGreed()
        {
            string commandString = "";

            //дописать условие, если не менеджер, то в запросе будет передаваться Name из Nameform!
            //объединяет таблицу Hours и users по столбцу ID и IDName
            if (roleform == "manager")
            {
                commandString =
               "SELECT [Date],[Hours],users.[Name],[Messang]" +
               "  FROM[Beregovoj].[dbo].[Hours] LEFT JOIN users ON Hours.IDName = users.ID";

            }
            else
            {
                commandString =
               "SELECT [Date],[Hours],users.[Name],[Messang]" +
               $"  FROM[Beregovoj].[dbo].[Hours] LEFT JOIN users ON Hours.IDName = users.ID where [Name] = '{UserName}'";

            }


            var adapter = new SqlDataAdapter(commandString, DbString);

            adapter.Fill(table);
            dataGridView1.Update();
        }

       


        private void button2_Click(object sender, EventArgs e)
        {
            /*
             проверяем, что зашли под менеджером и выбран ли элемент listBox1.
            получаем ID выбранного элемента(usera)

            входные данные-roleform для проверки роли

            входные данные- UserName
            входные данные-таблица tableUsers

            выходные данные ID (пользователя)
             */
            int IDUser = 0;
            DT IDnew = new DT();

            if (roleform == "manager" && listBox1.SelectedItem != null)
            {

                var IDString = listBox1.SelectedItem.ToString().Split(' ')[0];//поллучаем ID в виде строки из выбранного элемента listBox1
                IDUser = Int32.Parse(IDString);
            }
            else if (roleform != "manager")
            {

                IDUser = IDnew.ChekRole(tableUsers, UserName);//вызываем метод класса DT через созданный экземпляр IDnew класса DT,
                                                              //передаем в него параметры, присваиваем значение в переменную IDUser
            }
            else
            {
                MessageBox.Show("Пользователь не выбран!");
                return;
            }

            //данные из контролов сохраняем в переменные  
            var inputDate = Convert.ToDateTime(dateTimePicker1.Text);//конвертируем тип
            var inputHour = Convert.ToInt32(textBox2.Text);//конвертируем тип



            string inputMessang = textBox7.Text;

            SqlConnection connection = new SqlConnection(DbString); // создание подключения
            connection.Open();



            SqlCommand insertCommand = connection.CreateCommand(); // создание команды на вставку данных

            insertCommand.CommandText = $"INSERT INTO Hours ([Date],[Hours],[Messang],[IDName]) VALUES ( @p1, @p2, @p3, @p4 )";//создаем запрос на вставку данных
            //подготовка данных для SQL сервера
            DbParameter pio = insertCommand.CreateParameter();
            pio.ParameterName = "@p1";
            pio.DbType = DbType.DateTime;
            pio.Value = inputDate;
            insertCommand.Parameters.Add(pio);

            pio = insertCommand.CreateParameter();
            pio.ParameterName = "@p2";
            pio.DbType = DbType.Int32;
            pio.Value = inputHour;
            insertCommand.Parameters.Add(pio);

            pio = insertCommand.CreateParameter();
            pio.ParameterName = "@p3";
            pio.DbType = DbType.String;
            pio.Value = inputMessang;
            insertCommand.Parameters.Add(pio);

            pio = insertCommand.CreateParameter();
            pio.ParameterName = "@p4";
            pio.DbType = DbType.Int32;
            pio.Value = IDUser;
            insertCommand.Parameters.Add(pio);

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            connection.Close();

            LoadDataForGreed();
            DialogeCheck();

        }

        private static void DialogeCheck()
        {
            DialogResult result = MessageBox.Show(
                     "Желаете продолжить?",
                     "Сообщение",
                     MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                ManagerForm.ActiveForm.Activate();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
