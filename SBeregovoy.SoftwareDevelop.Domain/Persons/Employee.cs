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
       // public decimal TotalPay { get; }
        //public static DateTime startdates;
        //public static DateTime enddates;
        //public int sumhour;
       // public int totalHour;
        public static int stavka = 120000;
        public static decimal MonthBonus = 0;
        public Employee(User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate) : base(stavka, user, timeRecords, startdate, enddate, MonthBonus)
        {
            //startdates = startdate;
            //enddates = enddate;

            //decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            //decimal totalPay = 0;
           
            //foreach (var timeRecord in timeRecords)
            //{
            //    if (name == timeRecord.Name)
            //        if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
            //            if (timeRecord.Hours <= Settings.WorkHoursInMonth)
            //            {
            //                totalPay += payPerHour * timeRecord.Hours;
            //                totalHour += timeRecord.Hours;
            //            }
            //    else//переработка
            //    {
            //        totalPay += payPerHour * Settings.WorkHourInDay+(timeRecord.Hours- Settings.WorkHoursInMonth) * payPerHour;
            //    }
            //}
            //TotalPay = totalPay;
        }

        //public void PrintRepEmployee()
        //{

        //    foreach (TimeRecord item in base.TimeRecords)
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
