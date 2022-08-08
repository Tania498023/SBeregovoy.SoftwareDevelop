using SBeregovoy.SoftwareDevelop.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace SBeregovoy.SoftwareDevelop.Persistence
{
    public class FileRepository
    {
        public void FillFileUser(List<User> users, bool userneedwrite)
        {
            string userpath = "User.csv";
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
        

        //создаем общий метод для сотрудников
        public void FillFileGeneric(List<TimeRecord> timeRecords, int roles, bool genericneedwrite)
        {
          
            string newpath = "";

            if (roles == (int)UserRole.Manager)
            {
                newpath = "Manager.csv";
            }
            if (roles == (int)UserRole.Employee)
            {
                newpath = "Employee.csv";
            }
            else if (roles == (int)UserRole.Frelanser)
            {
                newpath = "Frilanser.csv";
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
        public List<User> ReadFileUser()
        {
            string userpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\User.csv";
            if (!File.Exists(userpath))
                return null;
            List<User> users = new List<User>();

            var strings = File.ReadAllLines(userpath);//получили массив строк
            UserRole strokainenum;

            foreach (var stroka in strings)
            {
                var plitedstroka = stroka.Split(',');
              
                    strokainenum = (UserRole)Enum.Parse(typeof(UserRole), plitedstroka[1]);

                var user = new User(plitedstroka[0], strokainenum);//создали  объект
                users.Add(user);// добавили объект в коллекцию
            }
            return users;
        }

        public List<TimeRecord> ReadFileGeneric(int roles)
        {
            string employeepath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Employee.csv";
            string frilanserpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Frilanser.csv";
            string managerpath = @"C:\Users\Tanya\source\repos\SBeregovoy.SoftwareDevelop\SoftwareDevelopConsole\Data\Manager.csv";
            string newpath = "";

            if (roles == (int)UserRole.Manager)
            {
                newpath = managerpath;
            }
            if (roles == (int)UserRole.Employee)
            {
                newpath = employeepath;
            }
            else if (roles == (int)UserRole.Frelanser)
            {
                newpath = frilanserpath;
            }
            
            if (!File.Exists(newpath))
                return null;
            List<TimeRecord> generic = new List<TimeRecord>();

            var strings = File.ReadAllLines(newpath);//получили массив строк
           

            foreach (var stroka in strings)
            {
                var plitedstroka = stroka.Split(',');
                               
                var user = new TimeRecord(plitedstroka);//создали  объект
                generic.Add(user);// добавили объект в коллекцию
            }
            return generic;
        }





    }
}



