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
        //public decimal TotalPay { get;}
        //public static DateTime startdates;
        //public static DateTime enddates;
        //public int sumhour;         
      //  public int totalHour;
        public static int stavka = 200000;
        public Manager(User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate) : base(stavka, user,  timeRecords, startdate,enddate, MonthBonus)
        {
          
            //startdates = startdate;
            //enddates = enddate;
            //NewMethod(name, timeRecords, startdate, enddate, bonusPerDay);
        }

        //private void NewMethod(string name, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate, decimal bonusPerDay)
        //{
        //    decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
        //    decimal totalPay = 0;
        // decimal bonusPerDay = MonthBonus / Settings.WorkHoursInMonth* Settings.WorkHourInDay;

        //    foreach (var timeRecord in timeRecords)
        //    {
        //        if (name == timeRecord.Name)
        //            if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
        //                if (timeRecord.Hours <= Settings.WorkHourInDay)
        //                {
        //                    totalPay += payPerHour * timeRecord.Hours;
        //                    totalHour += timeRecord.Hours;
        //                }
        //                else//переработка
        //                {
        //                    totalPay += payPerHour * Settings.WorkHourInDay + bonusPerDay;
        //                }
        //    }
        //    TotalPay = totalPay;
        //}
        //public void PrintRepManager()
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
//public void PrintRepFrilanser()
//{

//    foreach (TimeRecord item in base.TimeRecords)
//    {
//        if (item.Date >= startdates && item.Date <= enddates)
//            if (base.Name == item.Name)
//            {
//                Console.WriteLine($"Отчет по сотруднику {base.Name} за период c {startdates.Date.ToString("d")} по {enddates.Date.ToString("d")}");
//                Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
//                sumhour += item.Hours;

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