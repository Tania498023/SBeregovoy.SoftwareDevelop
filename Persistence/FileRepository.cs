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
        public void FillFileUser(List<User> users, bool userneedwrite)
        {
            string userpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\User.csv";
            if (!File.Exists(userpath))
                return;
            System.IO.FileInfo file = new System.IO.FileInfo(userpath);
            long size = file.Length;

            if (!userneedwrite && size > 0)
                return;

            foreach (User user in users)//перебираем коллекцию и выбираем из нее элементы
            {
                string userstr = user.Name + "," + user.UserRole + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
                File.AppendAllText(userpath, userstr);//записываем указанную строку 
            }
        }
        //public void FillFileEmployee(List<TimeRecord> timeRecords)
        //{


        //    foreach (TimeRecord emloyees in timeRecords)//перебираем коллекцию и выбираем из нее элементы
        //    {
        //        string employeestr = emloyees.Date + "," + emloyees.Name + "," + emloyees.Hours + "," + emloyees.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
        //        File.AppendAllText(employeepath, employeestr);//записываем указанную строку 

        //    }

        //}
        //public void FillFileFrilanser(List<TimeRecord> timeRecords)
        //{


        //    foreach (TimeRecord frilanser in timeRecords)//перебираем коллекцию и выбираем из нее элементы
        //    {
        //        string frilanserstr = frilanser.Date + "," + frilanser.Name + "," + frilanser.Hours + "," + frilanser.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
        //        File.AppendAllText(frilanserpath, frilanserstr);//записываем указанную строку 

        //    }

        //}
        //public void FillFileManager(List<TimeRecord> timeRecords)
        //{

           
        //    foreach (TimeRecord manager in timeRecords)//перебираем коллекцию и выбираем из нее элементы
        //    {
        //        string managerstr = manager.Date + "," + manager.Name + "+" + manager.Hours + "," + manager.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
        //        File.AppendAllText(managerpath, managerstr);//записываем указанную строку 

        //    }

        //}
        
        

        //создаем общий метод для сотрудников
        public void FillFileGeneric(List<TimeRecord> timeRecords, int UserRole, bool genericneedwrite)
        {
            
            string employeepath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Employee.csv";
            string frilanserpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Frilanser.csv";
            string managerpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Manager.csv";
            string newpath = "";

            if (UserRole == 0)
            {
                newpath = managerpath;
            }
            if (UserRole == 1)
            {
                newpath = employeepath;
            }
            else if (UserRole == 2)
            {
                newpath = frilanserpath;
            }

            if (!File.Exists(newpath))
                return;
            System.IO.FileInfo file = new System.IO.FileInfo(newpath);
            long size = file.Length;

            if (!genericneedwrite && size > 0)
                return;

            foreach (TimeRecord userrole in timeRecords)//перебираем коллекцию и выбираем из нее элементы
            {
                string genericstr = userrole.Date + "," + userrole.Name + "+" + userrole.Hours + "," + userrole.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
                File.AppendAllText(newpath, genericstr);//записываем указанную строку 
            }
            
        }




    }
}



