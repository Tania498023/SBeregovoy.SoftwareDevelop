using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Freelanser : Person
    {
        
        public Freelanser(User user, List<TimeRecord> timeRecords,DateTime startdate, DateTime enddate) : base(user, timeRecords, startdate, enddate)
        {
          

            decimal totalPay = 0;
            foreach (var timeRecord in timeRecords)
            {
                if (User.Name == timeRecord.Name)
                    if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                    {
                        totalPay += Settings.payPerHour * timeRecord.Hours;
                      
                    }
            }

            TotalPay = totalPay;
            

        }
        
    }


    
    
    
}

