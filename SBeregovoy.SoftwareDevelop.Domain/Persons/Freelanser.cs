using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Freelanser : Person
    {
        // public int totalHour;

        //public static DateTime startdates;
        //public static DateTime enddates;
        // public int sumhour;
       // User User;


        public Freelanser(User user, List<TimeRecord> timeRecords,DateTime startdate, DateTime enddate) : base(user, timeRecords, startdate, enddate)
        {
          //  User = user;
            //enddates = enddate;

            decimal totalPay = 0;
            foreach (var timeRecord in timeRecords)
            {
                if (User.Name == timeRecord.Name)
                    if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                    {
                        totalPay += Settings.payPerHour * timeRecord.Hours;
                        sumhour += timeRecord.Hours;
                    }
            }

            TotalPay = totalPay;
            

        }
        //public  void  PrintRepFrilanser()
        //{
            
        //    foreach (TimeRecord item in base.TimeRecords )
        //    {
        //        if (item.Date >= startdates && item.Date <= enddates)
        //            if (base.Name == item.Name)
        //            {
        //                Console.WriteLine($"Отчет по сотруднику {base.Name} за период c {startdates.Date.ToString("d")} по {enddates.Date.ToString("d")}");
        //                Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
        //                sumhour += item.Hours;
        //            }
        //    }
           
        //}

    }


    
    
    
}

