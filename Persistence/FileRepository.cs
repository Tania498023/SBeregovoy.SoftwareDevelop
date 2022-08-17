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
            string userpath = @".\Data\User.csv";
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
                newpath = @".\Data\Manager.csv";
            }
            if (roles == (int)UserRole.Employee)
            {
                newpath = @".\Data\Employee.csv";
            }
            else if (roles == (int)UserRole.Frelanser)
            {
                newpath = @".\Data\Frilanser.csv";
            }

            if (!File.Exists(newpath))
                return;
            System.IO.FileInfo file = new System.IO.FileInfo(newpath);
            long size = file.Length;

            if (!genericneedwrite && size > 0)
                return;

            foreach (TimeRecord userrole in timeRecords)//перебираем коллекцию и выбираем из нее элементы
            {
                string genericstr = userrole.Date + "," + userrole.Name + "," + userrole.Hours + "," + userrole.Message + Environment.NewLine;//создаем строку с разделительными символами и переносом строки
                File.AppendAllText(newpath, genericstr);//записываем указанную строку 
            }
            
        }
        public List<User> ReadFileUser()
        {
            string userpath = @".\Data\User.csv";
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
            string newpath = "";

            if (roles == (int)UserRole.Manager)
            {
                newpath = @".\Data\Manager.csv";
            }
            if (roles == (int)UserRole.Employee)
            {
                newpath = @".\Data\Employee.csv";
            }
            else if (roles == (int)UserRole.Frelanser)
            {
                newpath = @".\Data\Frilanser.csv";
            }
            
            if (!File.Exists(newpath))
                return null;
            List<TimeRecord> generic = new List<TimeRecord>();

            var strings = File.ReadAllLines(newpath);//получили массив строк
           

            foreach (var stroka in strings)
            {
                if (string.IsNullOrEmpty(stroka))
                    continue;
                var plitedstroka = stroka.Split(',');
                               
                var user = new TimeRecord(plitedstroka);//создали  объект
                generic.Add(user);// добавили объект в коллекцию
            }
            return generic;
        }
        public User UserGet(string name)
        {
            foreach (var record in ReadFileUser())
            {
                if (record.Name == name)
                    return record;
            }
            return null;
        }
        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = ReadFileGeneric((int)userRole);


        
            if (from == null)
            {
                from = DateTime.Now.Date.AddYears(-100);
            }
            if (to == null)
            {
                to = DateTime.Now.Date;
            }

            return records.Where(x => from.Value <= x.Date && x.Date <= to).ToList();
        }
        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x => x.Name == userName).ToList();
        }



    }
}



