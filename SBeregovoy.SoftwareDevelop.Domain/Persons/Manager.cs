using SBeregovoy.SoftwareDevelop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Manager : Staff
    {
        public static decimal MonthBonus => 20000;
       
        public static int stavka = 200000;
        public Manager(User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate) : base(stavka, user,  timeRecords, startdate,enddate, MonthBonus)
        {
          
            
        }

        

    }
}
