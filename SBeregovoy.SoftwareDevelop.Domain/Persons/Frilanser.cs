using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Frilanser : Person
    {
        public int totalHour;
        
        public static DateTime startdates;
        public static DateTime enddates;
        public int sumhour;

        public decimal TotalPay { get; }
        
        public Frilanser(string name, List<TimeRecord> timeRecords,DateTime startdate, DateTime enddate) : base(name, timeRecords)
        {
            startdates = startdate ;
            enddates = enddate ;
          
            decimal totalPay = 0;
            foreach (var timeRecord in timeRecords)
            {
                if (name == timeRecord.Name)
                    if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                    {
                        totalPay += Settings.payPerHour * timeRecord.Hours;
                        totalHour += timeRecord.Hours;
                    }
            }

            TotalPay = totalPay;
            

        }
        public  void  PrintRepFrilanser()
        {
            
            foreach (TimeRecord item in base.TimeRecords )
            {
                if (item.Date >= startdates && item.Date <= enddates)
                    if (base.Name == item.Name)
                    {
                        Console.WriteLine($"Отчет по сотруднику {base.Name} за период c {startdates.Date.ToString("d")} по {enddates.Date.ToString("d")}");
                        Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
                        sumhour += item.Hours;
                    }
            }
           
        }

    }


    
    
    
}

