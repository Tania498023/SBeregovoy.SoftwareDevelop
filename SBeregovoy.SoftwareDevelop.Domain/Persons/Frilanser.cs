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
        public static List<TimeRecord> printF;
        public static DateTime startdates;
        public static DateTime enddates;
        public static string freename;

        public decimal TotalPay { get; }
        
        public Frilanser(string name, List<TimeRecord> timeRecords,DateTime startdate, DateTime enddate) : base(name, timeRecords)
        {
            startdates = startdate ;
            enddates = enddate ;
            freename = name ;
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
        public  static void  PrintRepFrilanser()
        {

            foreach (var item in printF)
            {
                if (item.Date >= startdates && item.Date <= enddates)
                    if (freename == item.Name)
                    {
                        Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
                        Console.ReadLine();
                    }
            }
            
            
        }

    }


    
    
    
}

