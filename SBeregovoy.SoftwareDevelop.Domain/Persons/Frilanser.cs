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
        public List<TimeRecord> printF;
        public decimal TotalPay { get; }
        
        public Frilanser(string name, List<TimeRecord> timeRecords,DateTime startdate, DateTime enddate) : base(name, timeRecords)
        {
            printF =timeRecords;
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
        public  static void  PrintRepFrilanser(List<TimeRecord> timeRecords)
        {

            foreach (var timeRecord in timeRecords)
            {
                if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                    if (==timeRecord.Name)
                    {
                        Console.WriteLine(timeRecord.Date + "\t" + timeRecord.Hours + "\t" + timeRecord.Message);//реализ метода в Фрил
                        Console.ReadLine();
                    }
            }
            
            
        }

    }


    
    
    
}

