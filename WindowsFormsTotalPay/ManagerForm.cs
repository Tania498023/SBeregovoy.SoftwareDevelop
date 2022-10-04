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

        public ManagerForm()
        {
            
        }

        public ManagerForm(string _roleform, string name)
        {
            InitializeComponent();
            this.roleform = _roleform;
            this.UserName = name;
           
            //добавить лейбл на форму и присвоить ему полученную роль
            if (roleform == "manager")
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                
                textBox7.Visible = true;
               
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                listBox1.Visible = true;
                comboBoxRole.Visible = true;
                LoadUsers();
                LoadRole();
            }

            if (roleform == "freelanser" || roleform == "employee")
            {
                
                textBox2.Visible = true;
               
                button2.Visible = true;
             

            }
        }

        private  void LoadUsers()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
          //  [ID] из запроса не удаляем, используется дальше в коде
            string cmd = $"SELECT users.[ID],[Name],[Role] FROM [Beregovoj].[dbo].[UserRole] Right JOIN users ON users.IDRole = [UserRole].ID ";
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            foreach (DataRow row in table.Rows)
            {
                string r = "";
                int r1 = 0;
                string role = "";
                foreach (DataColumn column in table.Columns)
                {

                    role = row[column].ToString();
                        
                        r += role + ",";

                        r1++;
                        if(r1 == 2)
                            listBox1.Items.Add(r);
         
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

            string role = "";

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

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        /* хранимая процедура
USE [Beregovoj]
GO
Object:  StoredProcedure [dbo].[sp_CreateUser]    Script Date: 30.09.2022 14:21:54 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE[dbo].[sp_CreateUser]
@date smalldatetime,
@hours int,
@name nvarchar(50),
@Messang nvarchar(50),
@Idname int,
@Id int out
AS
INSERT INTO Hours([Date], [Name], [Hours], [Messang], [IDName])
VALUES(@date, @hours, @name, @messang, @Idname)


SET @Id = SCOPE_IDENTITY()
*/


        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран!");
                return;
            }
           var IDString = listBox1.SelectedItem.ToString().Split(',')[0];//поллучаем ID в виде строки из выбранного элемента listBox1
            int IDUser = Int32.Parse(IDString);
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

           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

          //  textBox1.Clear();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }
    }
}
