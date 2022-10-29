using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Staff : Person
    {

        public int totalHour;
        public decimal MonthSalary { get; }
        decimal Bonus;


        public Staff(decimal monthSalary, User user, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate, decimal bonus) : base(user, timeRecords, startdate, enddate)
        {
            Bonus = bonus;
            MonthSalary = monthSalary;
            RaschetTotalPay(User.Name, timeRecords, startdate, enddate);
        }

        private void RaschetTotalPay(string name, List<TimeRecord> timeRecords, DateTime startdate, DateTime enddate)
        {

            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal totalPay = 0;
            decimal bonusPerDay = Bonus / Settings.WorkHoursInMonth * Settings.WorkHourInDay;


            foreach (var timeRecord in timeRecords)
            {
                if (name == timeRecord.Name)
                    if (timeRecord.Date >= startdate && timeRecord.Date <= enddate)
                        if (timeRecord.Hours <= Settings.WorkHourInDay)
                        {
                            totalPay += payPerHour * timeRecord.Hours;
                            totalHour += timeRecord.Hours;
                        }
                        else if (User.UserRole == UserRole.Manager)//переработка
                        {
                            totalPay += payPerHour * Settings.WorkHourInDay + bonusPerDay;//для менеджера
                        }
                        else
                        { 

                          totalPay += payPerHour * timeRecord.Hours + (timeRecord.Hours - Settings.WorkHourInDay) * payPerHour;//для Employee

                        }
                TotalPay = totalPay;
            }

        }
    }
}
