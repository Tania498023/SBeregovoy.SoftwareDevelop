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
        
        /// <summary>
        /// Получаем ID роли по имени из таблицы
        /// </summary>
        /// <param name="Tbl"></param>
        /// <param name="Names"></param>
        /// <returns></returns>
       
        public int GetIdByName(DataTable Tbl, string Namestring)
        {
            int IDUser = 0;
       
            foreach (DataRow row in Tbl.Rows)
            {
                var ID = 0;
                foreach (DataColumn column in Tbl.Columns)
                {
                    //найти имя (Names) в таблице Tbl с полным совпадением имени
                    //по найденному имени получить ID

                   
                    var str = row[column].ToString();

                    if ( int.TryParse(str, out int U))
                    {
                        ID = U;

                    }
                    if ( str == Namestring)
                    {
                        IDUser = ID;
                        return IDUser;
                    }


                }

            }
            

            return IDUser;

        }

    }
}
