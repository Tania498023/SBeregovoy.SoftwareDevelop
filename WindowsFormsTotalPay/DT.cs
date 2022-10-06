using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTotalPay
{
    public class DT
    {
        public int ChekRole(DataTable Tbl, string Names)
        {
            int IDUser = 0;
            int IDnew = 0;

            List<string> id = new List<string>();

            foreach (DataRow row in Tbl.Rows)
            {
                string us = "";
                int us1 = 0;
                
                foreach (DataColumn column in Tbl.Columns)
                {
                    var str = row[column].ToString();
                   

                    us += str + " ";

                    us1++;
                    if (us1 == 2)
                       id.Add(us);

                }

            }
            foreach (var item in id)
            {
                if(item.Contains(Names))//переопределить свой Compare чтоб было полное совпадение или переписать другим способом
                {
                    IDUser = Int32.Parse(item.Split(' ')[0]);
                    
                }
            }

            return IDUser;

        }

        // foreach (DataRow row in tableUsers.Rows)//в первом цикле это первая строка
        //    {
        //        string us = "";
        //        int us1 = 0;
        //        string usn = "";
        //        foreach (DataColumn column in tableUsers.Columns)
        //        {

        //            usn = row[column].ToString();

        //us += usn + " ";

        //                us1++;
        //                if(us1 == 2)
        //                    listBox1.Items.Add(us);
         

    }
}
