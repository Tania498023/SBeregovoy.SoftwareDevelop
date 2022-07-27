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
        public Manager(string name, List<TimeRecord> timeRecords) : base(name, 200000, timeRecords)
        {
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal totalPay = 0;
            decimal bonusPerDay = MonthBonus / Settings.WorkHoursInMonth * Settings.WorkHourInDay;

            foreach (var timeRecord in timeRecords)
            {
                if (timeRecord.Hours <= Settings.WorkHourInDay)
                {
                    totalPay += payPerHour * timeRecord.Hours;
                }
                else//переработка
                {
                    totalPay += payPerHour * Settings.WorkHourInDay + bonusPerDay ;
                }    
            }
            TotalPay = totalPay;
        }
        
    }
}
