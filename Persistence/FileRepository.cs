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
        /// <summary>
        /// Записываем коллекцию в файл user.csv 
        /// </summary>
        /// <param name="users"></param>
        /// <param name="userneedwrite"></param>
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


        /// <summary>
        /// Записываем коллекцию TimeRecord в файл согласно роли
        /// </summary>
        /// <param name="timeRecords"></param>
        /// <param name="roles"></param>
        /// <param name="genericneedwrite"></param>
        public void FillFileGeneric(List<TimeRecord> timeRecords, int roles, bool genericneedwrite)
        {
            string newpath = ConvertRoleToPath(roles);

            if (!File.Exists(newpath))
                return;
            System.IO.FileInfo file = new System.IO.FileInfo(newpath);
            long size = file.Length;

            if (!genericneedwrite && size > 0)
                return;

            foreach (TimeRecord userrole in timeRecords)//перебираем коллекцию и выбираем из нее элементы
            {
                //создаем строку с разделительными символами и переносом строки
                string genericstr = userrole.Date + "," + userrole.Name + "," + userrole.Hours + "," + userrole.Message + Environment.NewLine;

                File.AppendAllText(newpath, genericstr);//записываем указанную строку 
            }
        }

        /// <summary>
        /// Конвертируем тип int(роль) в string(путь к файлу) 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        private static string ConvertRoleToPath(int roles)
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

            return newpath;
        }
        /// <summary>
        /// Считывает все строки файла User.csv и закрывает файл
        /// </summary>
        /// <returns></returns>
        public List<User> ReadFileUser()
        {
            var defaultuser = new User("defaultuser", UserRole.Manager);
            var tmplist = new List<User>();
            tmplist.Add(defaultuser);

            string userpath = @".\Data\User.csv";
            if (!File.Exists(userpath))
                return tmplist;
            List<User> users = new List<User>();

            var strings = File.ReadAllLines(userpath);//получили массив строк
            UserRole strokainenum;

            foreach (var stroka in strings)
            {
               if (string.IsNullOrEmpty(stroka) || string.IsNullOrWhiteSpace(stroka))
                    continue;
                var plitedstroka = stroka.Split(',');

                strokainenum = (UserRole)Enum.Parse(typeof(UserRole), plitedstroka[1]);

                var user = new User(plitedstroka[0], strokainenum);//создали  объект
                users.Add(user);// добавили объект в коллекцию
            }
            if(users.Count == 0)
            {
                return tmplist;
            }
            return users;
        }
        /// <summary>
        /// Считывает все строки файла согласно роли
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<TimeRecord> ReadFileGeneric(int roles)
        {
            string newpath = ConvertRoleToPath(roles);

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
        /// <summary>
        /// Получаем имя пользователя и возвращаем коллекцию User
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User UserGet(string name)
        {
            foreach (var record in ReadFileUser())
            {
                if (record.Name == name)
                    return record;
            }
            return null;
        }
        /// <summary>
        /// Получаем отчет по сотрудникам с учетом роли 
        /// </summary>
        /// <param name="userRole"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? startdate = null, DateTime? enddate = null)
        {
            var records = ReadFileGeneric((int)userRole);

            if (startdate == null)
            {
                startdate = DateTime.Now.Date.AddYears(-100);
            }
            if (enddate == null)
            {
                enddate = DateTime.Now.Date;
            }

            //берем каждую запись из коллекции records и сравниваем ее с переменной, которая передана в метод.
            //если условие выполняется, то кладем элемент в ToList(). Where- аналог foreach с if/else. x- виртуальная переменная
            // коллекции records- аналог item.Условие в данном случае: если x.Date меньше или равно конечной даты enddate(максимальная)
            // и x.Date больше или равно начальной даты startdate(минимальная)
            return records.Where(x => startdate.Value <= x.Date && enddate >= x.Date).ToList();
        }
        /// <summary>
        /// Получаем отчет по конкретному сотруднику
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userRole"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x => x.Name == userName).ToList();
        }



    }
}



