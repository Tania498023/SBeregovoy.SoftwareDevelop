using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsTotalPay;

namespace WindowsFormsTotalPay
{
    public partial class ManagerForm : Form
    {
        private readonly string MFroles;
        private string UserName;

        DataTable tableUsers = new DataTable();
        DataTable tableRole = new DataTable();
        DataTable tableGreed = new DataTable();
        public ManagerForm(string roles, string name)
        {
            InitializeComponent();
            MFroles = roles;
            UserName = name;
            EnterName.Text = UserName;
            EnterRole.Text = MFroles;
            EnterUsers.Text = UserName;
            EnterRoles.Text = MFroles;

            //добавить лейбл на форму и присвоить ему полученную роль
            if (MFroles == "manager")
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
                lbUserNames.Visible = true;
                comboBoxRole.Visible = true;
                delButton.Visible = true;
                comboxPolzovatelName.Visible = true;
                label7.Visible = true;


                LoadRole();
            }

            if (MFroles == "freelanser" || MFroles == "employee")
            {

                textBox2.Visible = true;
                button2.Visible = true;
          
            }
            LoadUsers();
        }


       
        private  void LoadUsers()//загружаем имя пользователя(usera) в lbUserName
        {
            string cmd = $"SELECT users.[ID],[Name],[Role] FROM [Beregovoj].[dbo].[UserRole] Right JOIN users ON users.IDRole = [UserRole].ID ";


            tableUsers.Clear();
            FeelTables(ref tableUsers, cmd);

            foreach (DataRow row in tableUsers.Rows)//в первом цикле это первая строка
            {

                string summuser = "";
                int indexofword = 0;
                string Usr = "";
                foreach (DataColumn column in tableUsers.Columns)
                {

                    Usr = row[column].ToString();

                    summuser += Usr + " ";

                    indexofword++;
                    if (indexofword == 2)
                    {
                        lbUserNames.Items.Add(summuser);
                        comboxPolzovatelName.Items.Add(summuser);
                    }

                }

            }
            
            
        }
        
        private void LoadRole()
        {
            
            //  [ID] из запроса не удаляем, используется дальше в коде
            string cmd = $"SELECT [ID],[Role] FROM [Beregovoj].[dbo].[UserRole] ";

            FeelTables(ref tableRole, cmd);

            
            foreach (DataRow row in tableRole.Rows)
            {
                string role;
                string summrole = "";
                int indexofword= 0;
                foreach (DataColumn column in tableRole.Columns)
                {

                    role = row[column].ToString();

                    summrole += role + ",";

                    indexofword++;
                    if (indexofword == 2)
                        comboBoxRole.Items.Add(summrole);

                }

            }


        }

        private void FeelTables(ref DataTable table, string cmd)
        {
            DB db = new DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }

        //сформировать запрос с полученными переменными и выполнить запрос к БД с Инсерт для записи данных
        //очистить ЛистБокс
        //загрузить из БД новый набор данных и добавить его в ТекстБокс
        private void button1_Click(object sender, EventArgs e)
        {

            var inputName = textBox1.Text;
            if (!Int32.TryParse(inputName, out int SS))
            {

            }
            else
            {
                MessageBox.Show("Имя пользователя не может быть числом!");
                return;
            }
            if (String.IsNullOrEmpty(inputName) || String.IsNullOrWhiteSpace(inputName))
            {
                MessageBox.Show("Введите пользователя!");
                return;
            }


            if (comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Роль не выбрана!");
                return;
            }
            var NameByTbl = new DT();//создали экземпляр класса DT
            var GetName = NameByTbl.GetIdByName(tableUsers, inputName);//через экземпляр NameByTbl класса DT вызвали метод GetIdByName (обязательно указываем сигнатуру)

            
            if (GetName != 0)// если метод GetIdByName вернул  не 0 (тип int, так как в сигнатуре второй параметр int), а какое то значение, значит в таблице уже есть вводимое имя
            {
                MessageBox.Show("Такой пользователь уже существует!");
                return;
            }
            
         

            var RoleString = comboBoxRole.SelectedItem.ToString().Split(',')[0];
            int RoleUser = Int32.Parse(RoleString);

            
            var cmdstring = $"INSERT INTO users ([Name],[IDRole]) VALUES ('{inputName}', '{RoleUser}')";

            EcxecSqlCmd(cmdstring);
     
            DialogeCheck();
       
        }

        private void EcxecSqlCmd(string cmdstring)
        {
            SqlConnection connection = new SqlConnection(DB.connect); // создание подключения
            connection.Open();

            SqlCommand insertCommand = connection.CreateCommand(); // создание команды на вставку данных
            insertCommand.CommandText = cmdstring;

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            connection.Close();

            lbUserNames.Items.Clear();
            comboxPolzovatelName.Items.Clear();
            LoadUsers();
        }


        private void delButton_Click(object sender, EventArgs e)
        {
            if(lbUserNames == null || lbUserNames.SelectedItem == null)
            {
                return;
            }
            var del = lbUserNames.SelectedItem.ToString().Split(' ')[1];
           
            var cmdstring = $"Delete  users where [Name] = '{del}'";//подготовка запроса

            EcxecSqlCmd(cmdstring);

        }
       
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadDataForGreed();
            dataGridView1.DataSource = tableGreed;//обновление dataGridView1 из таблицы SQL
        }

        private void LoadDataForGreed()
        {
            string commandString;

            //дописать условие, если не менеджер, то в запросе будет передаваться Name из Nameform!
            //объединяет таблицу Hours и users по столбцу ID и IDName
            if (MFroles == "manager")
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

            FeelTables(ref tableGreed, commandString);
            
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
            int IDUser;
            DT IDnew = new DT();
            string localUserName = UserName;

            if (MFroles == "manager" && comboxPolzovatelName.SelectedItem != null)
            {

                var IDString = comboxPolzovatelName.SelectedItem.ToString().Split(' ')[0];//поллучаем ID в виде строки из выбранного элемента listBox1
                IDUser = Int32.Parse(IDString);

                localUserName = comboxPolzovatelName.SelectedItem.ToString().Split(' ')[1];
            }
            else if (MFroles != "manager")
            {

                IDUser = IDnew.GetIdByName(tableUsers, UserName);//вызываем метод класса DT через созданный экземпляр IDnew класса DT,
                                                              //передаем в него параметры, присваиваем значение в переменную IDUser
            }
            else
            {
                MessageBox.Show("Пользователь не выбран!");
                return;
            }

            //данные из контролов сохраняем в переменные  
            var inputDate = Convert.ToDateTime(dateTimePicker1.Text);//конвертируем тип
            if(inputDate >= DateTime.Now)
            {
                MessageBox.Show("Дата не может быть будущим числом!");
                return;
            }
            if(MFroles == "freelanser" && inputDate <= DateTime.Now.Date.AddDays(-2))
            {
                MessageBox.Show("Дата не может быть позднее двух дней от текущей даты!");
                return;
            }

            var D = textBox2.Text;
            int inputHour;
            
            if (String.IsNullOrEmpty(D)||String.IsNullOrWhiteSpace(D))
            {
                MessageBox.Show("Введите количество отработанных часов!");
                return;
            }

            if (Int32.TryParse(D, out inputHour)&& inputHour<24)
            {

            }   
            else
            {
                MessageBox.Show("Введен неверный формат часов!");
                return;
            }

            var Mes = textBox7.Text;
           // string inputMessang = ""; 
            if (String.IsNullOrEmpty(Mes) || String.IsNullOrWhiteSpace(Mes))
            {
                MessageBox.Show("Введите содержание работ!");
                return;
            }
            if (!Int32.TryParse(Mes, out int SSS))
            {

            }
            else
            {
                MessageBox.Show("Содержание работ не может быть числом!");
                return;
            }

            if (IDUser == 0)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

           

            SqlConnection connection = new SqlConnection(DB.connect); // создание подключения
            connection.Open();

            SqlCommand insertCommand1 = connection.CreateCommand(); // создание команды на вставку данных
            insertCommand1.CommandText = $"SELECT [Date],users.[Name] FROM[Beregovoj].[dbo].[Hours] LEFT JOIN users ON Hours.IDName = users.ID " +
                $" where [Name] = @p1 AND [Date] = @p2";

            DbParameter pio1 = insertCommand1.CreateParameter();
            pio1.ParameterName = "@p1";
            pio1.DbType = DbType.String;
            pio1.Value = localUserName;
            insertCommand1.Parameters.Add(pio1);

            pio1 = insertCommand1.CreateParameter();
            pio1.ParameterName = "@p2";
            pio1.DbType = DbType.DateTime;
            pio1.Value = inputDate;
            insertCommand1.Parameters.Add(pio1);

           

            DbDataReader reader = insertCommand1.ExecuteReader();
            string value = null;
            while (reader.Read())
            {
                
                if(!reader.IsDBNull(0))
                {
                    value = reader.GetDateTime(0).ToString();
                }
            
            }
          reader.Close();

        
          

            if(value != null)
            {
                MessageBox.Show("Запись по данному пользователю в указанную дату уже введена!");
                connection.Close();
                return;
            }

            SqlCommand insertCommand = connection.CreateCommand();
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
            pio.Value = Mes;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var TT = (sender as TextBox)?.Text;
          
            
            if (Int32.TryParse(TT, out int value))
            {

            }
            else
            {
                MessageBox.Show("Введите верный формат отработанных часов!");
            }
        }
    }
}
