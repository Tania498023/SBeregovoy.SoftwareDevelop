using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTotalPay
{
    internal class DB
    {
        public static string connect = @"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True";
        //строка подключения для внешнего сервера
        //string conStr = @"Data Source=Serv12; Persist Security Info = False; User ID = sql; Password =  CRKM.pth; Initial Catalog = Beregovoj; ";



        SqlConnection connection = new SqlConnection(connect);

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    
    }
}
