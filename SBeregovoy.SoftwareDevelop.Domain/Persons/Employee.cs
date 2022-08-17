using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Employee : Staff
    {
        public decimal TotalPay { get; }
        public Employee(string name, List<TimeRecord> timeRecords) : base(name, 120000, timeRecords)
        { 
        
        
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal totalPay = 0;
         
            foreach (var timeRecord in timeRecords)
            {
                if (timeRecord.Hours <= Settings.WorkHoursInMonth)
                {
                    totalPay += payPerHour * timeRecord.Hours;
                }
                else//переработка
                {
                    totalPay += payPerHour * Settings.WorkHourInDay+(timeRecord.Hours- Settings.WorkHoursInMonth) * payPerHour;
                }
            }
            TotalPay = totalPay;
        }
    }
    
}
