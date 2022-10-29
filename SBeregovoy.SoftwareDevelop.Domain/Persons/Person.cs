using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Person
    {
        public static DateTime startdates;
        public static DateTime enddates;
        public int sumhour;
        public static  User User { get; set; }
      
        public decimal TotalPay { get; set; }
        public List<TimeRecord> TimeRecords { get; set; }

        //public Person( List<TimeRecord> timeRecords)
        //{
            
        //    TimeRecords = timeRecords;
        //}

        public Person( User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate)
        {
           
            User = user;
            TimeRecords = timeRecords;
            startdates = startdate;
            enddates = enddate;
            


        }
            public void PrintRepPerson()
        {
            Console.WriteLine($"Отчет по сотруднику {User.Name}  {User.UserRole} за период c {startdates.Date.ToString("d")} по {enddates.Date.ToString("d")}");

            foreach (TimeRecord item in TimeRecords)
            {
                if (item.Date >= startdates && item.Date <= enddates)
                

                if (User.Name == item.Name)
                        {
                            Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
                            sumhour += item.Hours;
                        }
                    
            }

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

    }

}
