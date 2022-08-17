using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Manager : Staff
    {
        public decimal MonthBonus => 20000;
        public decimal TotalPay { get;}
        public static DateTime startdates;
        public static DateTime enddates;
        public int sumhour;         
        public int totalHour;
        public Manager(string name, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate) : base(name, 200000, timeRecords)
        {
            startdates = startdate;
            enddates = enddate;
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal totalPay = 0;
            decimal bonusPerDay = MonthBonus / Settings.WorkHoursInMonth * Settings.WorkHourInDay;

            foreach (var timeRecord in timeRecords)
            {
                if (name == timeRecord.Name)
                    if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                        if (timeRecord.Hours <= Settings.WorkHourInDay)
                        {
                        totalPay += payPerHour * timeRecord.Hours;
                        totalHour += timeRecord.Hours;
                        }
                else//переработка
                {
                    totalPay += payPerHour * Settings.WorkHourInDay + bonusPerDay ;
                }    
            }
            TotalPay = totalPay;
        }
        public void PrintRepManager()
        {

            foreach (TimeRecord item in base.TimeRecords)
            {
                if (item.Date >= startdates && item.Date <= enddates)
                    if (base.Name == item.Name)
                    {
                        Console.WriteLine(item.Date + "\t" + item.Hours + "\t" + item.Message);
                        sumhour += item.Hours;
                    }
            }

        }

    }
}
