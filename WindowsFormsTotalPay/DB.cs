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
        static string connect = @"
Server=(LocalDB)\mssqllocaldb;
Database=Beregovoj;
Trusted_Connection=True";

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
