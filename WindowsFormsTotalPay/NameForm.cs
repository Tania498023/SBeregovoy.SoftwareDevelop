using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTotalPay
{
    public partial class NameForm : Form
    {
        string roleform;
        public NameForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void namelabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void namelabel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //найти имя по переданной строке в loginField. В наборе полученных данных найти роль вошедшего пользователя для определения доступа в ManagerForm и соответствующего меню.  
        private void ButtonName_Click(object sender, EventArgs e)
        {
            string nameUser = loginField.Text;
            
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmd = $"SELECT users.[ID],[Name],[Role] FROM [Beregovoj].[dbo].[UserRole] Right JOIN users ON users.IDRole = [UserRole].ID  where [Name] = '{nameUser}'";
            SqlCommand command = new SqlCommand(cmd, db.GetConnection());
            
            adapter.SelectCommand = command;
            adapter.Fill(table);
            

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    
                    if(column.ColumnName == "Role")
                    {
                        roleform = row[column].ToString();
                       
                    }
                   
                }
           
            }
           if(roleform != null)
            {
                
                ManagerForm managerForm = new ManagerForm(roleform, nameUser);
                managerForm.Show();
                
                this.Visible = false;
            }



        }

        
    }
}
