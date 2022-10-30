using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Employee : Staff
    {
       
        public static int stavka = 120000;
        public static decimal MonthBonus = 0;
        public Employee(User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate) : base(stavka, user, timeRecords, startdate, enddate, MonthBonus)
        {
            

        }

       
    }
    
}
