using SBeregovoy.SoftwareDevelop.Domain;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Persistence
{
    public class FileRepository
    {
        public void FillFileUser(List<User> users)
        {

            string userpath = @"C: \Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\User.csv";
            foreach (User user in users)//перебираем коллекцию и выбираем из нее элементы
            {
                string userstr = user.Name + "," + user.UserRole + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
                File.AppendAllText(userpath, userstr);//записываем указанную строку 

            }

        }
        public void FillFileEmployee(List<TimeRecord> timeRecords)
        {

            string employeepath = @"C: \Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Employee.csv";
            foreach (TimeRecord emloyees in timeRecords)//перебираем коллекцию и выбираем из нее элементы
            {
                string employeestr = emloyees.Date + "," + emloyees.Name + emloyees.Hours + emloyees.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
                File.AppendAllText(employeepath, employeestr);//записываем указанную строку 

            }

        }со
    }
}
//сделать аналогично на 2 коллекции

