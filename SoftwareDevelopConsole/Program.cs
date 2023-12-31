﻿using NPOI.SS.Formula.Functions;
using Prometheus;
using SBeregovoy.SoftwareDevelop.Domain;
using SBeregovoy.SoftwareDevelop.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.SoftwareDevelopConsole
{
    internal class Program
    {
        static FileRepository fill;
        private static User polzovatel;


        static void Main(string[] args)

        {
            int userRole = 0;

            fill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser

            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            fill.FillFileUser(userreturn.Users(), false);


            var genericreturn = new MemoryRepository();
            fill.FillFileGeneric(genericreturn.Generic(), userRole, false);

            var text = fill.ReadFileUser();

            ControlRole(fill);
        }
        public static void ControlRole(FileRepository userreturn)//контроль вводимой роли при входе в программу
        {
            do
            {
                Console.WriteLine("Введите ваше имя");
                string name = Console.ReadLine();
                polzovatel = userreturn.UserGet(name);
                if (polzovatel == null)
                    Console.WriteLine("Пользователь с таким именем не существует");
            }
            while (polzovatel == null);
            DisplayMenu(polzovatel.UserRole);

        }

        private static UserRole InputRole()
        {
            UserRole enteruser = default;
            do
            {
                Console.WriteLine("\n Введите 0, если менеджер \n Введите 1, если сотрудник \n Введите 2, если фрилансер");
                int controleRole;

                if (Int32.TryParse(Console.ReadLine(), out controleRole))
                {

                    if (controleRole == (int)UserRole.Manager)
                    {
                        enteruser = UserRole.Manager;
                        break;
                    }
                    else if (controleRole == (int)UserRole.Employee)
                    {
                        enteruser = UserRole.Employee;
                        break;
                    }
                    else if (controleRole == (int)UserRole.Frelanser)
                    {
                        enteruser = UserRole.Frelanser;
                        break;
                    }
                    else
                        Console.WriteLine("Вы ввели несуществующую роль");

                }
            } while (enteruser < UserRole.Manager || enteruser > UserRole.Frelanser);

            return enteruser;
        }

        private static void DisplayMenu(UserRole userRole)
        {
            do
            {

                if (userRole == UserRole.Manager)
                {
                    Console.WriteLine("Меню Руководитель");
                    Showmanagermenu();
                    break;
                }
                if (userRole == UserRole.Employee)
                {
                    Console.WriteLine("Меню Сотрудник");
                    Showemployeemenu();
                    break;
                }
                if (userRole == UserRole.Frelanser)
                {
                    Console.WriteLine("Меню Фрилансер");
                    Showfrilansermenu();
                    break;
                }

            }
            while (true);

        }

        private static void Showmanagermenu()
        
        {
            int actionmanager;
            do
            {
                Console.WriteLine("Выберите действие  \n " +
                    "Введите 1, если вы хотите добавить сотрудника \n " +
                    "Введите 2, если вы хотите добавить время сотруднику \n " +
                    "Введите 3, если вы хотите посмотреть отчет по всем сотрудникам (возможность выбрать период) \n " +
                    "Введите 4, если вы хотите посмотреть часы работы сотрудника \n " +
                    "Введите 0, если вы хотите выйти из программы");


                if (Int32.TryParse(Console.ReadLine(), out actionmanager))
                {

                    if (actionmanager == 1)
                    {
                        AddWorker();
                        break;
                    }
                    else if (actionmanager == 2)
                    {
                        AddWorkerHour();
                        break;
                    }
                    else if (actionmanager == 3)
                    {

                        WatchWorkerReport();
                        break;
                    }
                    else if (actionmanager == 4)
                    {

                        WatchWorkerHour();
                        break;
                    }

                    else if (actionmanager == 0)
                    {

                        Exitprogram();
                        break;
                    }
                    else
                        Console.WriteLine("Вы выбрали несуществующее действие");
                }
            }

            while ((actionmanager < 1 || actionmanager > 4) && actionmanager != 0);
        }


        private static void Showemployeemenu()
        {
            int actionemployee;
            do
            {
                Console.WriteLine("Выберите действие  \n " +
                    "Введите 1, если вы хотите ввести часы \n " +
                    "Введите 2, если вы хотите просмотреть часы");

                if (Int32.TryParse(Console.ReadLine(), out actionemployee))
                {

                    if (actionemployee == 1)
                    {
                        AddStaffHour();
                        break;
                    }
                    else if (actionemployee == 2)
                    {
                        WatchStaffHour();
                        break;
                    }
                    else
                        Console.WriteLine("Вы выбрали несуществующее действие");
                }
            }

            while (actionemployee < 1 || actionemployee > 2);
        }
        private static void Showfrilansermenu()
        {
            int actionfrilanser;
            do
            {
                Console.WriteLine("Выберите действие  \n " +
                    "Введите 1, если вы хотите ввести часы \n " +
                    "Введите 2, если вы хотите просмотреть часы");

                if (Int32.TryParse(Console.ReadLine(), out actionfrilanser))
                {

                    if (actionfrilanser == 1)
                    {
                        AddStaffHour();
                        break;
                    }
                    else if (actionfrilanser == 2)
                    {
                        WatchStaffHour();
                        break;
                    }
                    else
                        Console.WriteLine("Вы выбрали несуществующее действие");
                }
            }

            while (actionfrilanser < 1 || actionfrilanser > 2);
        }

        private static void Exitprogram()
        {
            Environment.Exit(0);
        }
        private static void WatchStaffHour()
        {
            WatchHour();
            MenuUp();
        }
       
        private static void WatchHour()
        {
            List<TimeRecord> HH = fill.ReadFileGeneric((int)polzovatel.UserRole);//!!!метод вернул коллекцию, сохранили в переменную

            DateTime startdate;
            DateTime enddate;
           
            do
            {
                Console.WriteLine("Введите дату начала отчета");

                var D = Console.ReadLine();
                if(String.IsNullOrEmpty(D))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(D, out startdate))
                {

                }
                else
                {
                    Console.WriteLine("Введенная дата неверная!");
                    continue;
                }
                
                Console.WriteLine("Введите дату окончания отчета");
                var DD = Console.ReadLine();
                if (String.IsNullOrEmpty(DD))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(DD, out enddate))
                {

                }
                else
                {
                    Console.WriteLine("Введенная дата неверная!");
                    continue;
                }
                if (enddate < startdate)
                {
                    Console.WriteLine("Вы  вводите некорректную дату");

                }
                else
                    break;
            }
            while (true);


            foreach (var item in HH)
            {
                if (item.Date >= startdate && item.Date <= enddate)

                {
                    if (item.Name == polzovatel.Name)
                    {
                        Console.WriteLine(item.Date.ToString() + "\t" + item.Name + "\t" + item.Hours + "\t" + item.Message);
                    }
                    
                }
                
             
            }
            Console.ReadLine();
        }

        private static void AddStaffHour()
        {
            AddHour();
            MenuUp();
        }

        private static void AddHour()


        {
            int H;
            DateTime date;

            do
            {
                Console.WriteLine("Введите отработанное время");
                if (Int32.TryParse(Console.ReadLine(), out H))

                {
                    if (H <= 0 || H >= 24)
                    {
                        Console.WriteLine("Вы вводите некорректные данные");

                    }
                    Console.WriteLine("Введите дату");
                    if (DateTime.TryParse(Console.ReadLine(), out date))
                        if (date != DateTime.MinValue && date <= DateTime.Now && polzovatel.UserRole == UserRole.Employee)
                        {
                            AddHourWithControleDate(polzovatel,H, date);
                        }
                        else if (date != DateTime.MinValue && date <= DateTime.Now && date >= DateTime.Now.Date.AddDays(-2) && polzovatel.UserRole == UserRole.Frelanser)
                        {
                            AddHourWithControleDate(polzovatel,H, date);
                        }
                        else
                        {
                            Console.WriteLine("Дата введена некорректно!");
                        }


                    else
                    {
                        Console.WriteLine("Поле дата не может быть пустым!");
                    }

                }

            }
            while ((H <= 0 || H >= 24));
        }

        private static void AddHourWithControleDate(User Us, int H, DateTime date)
        {
            Console.WriteLine("Введите сообщение");
            string mas = Console.ReadLine();

            var time = new TimeRecord(date, Us.Name, H, mas);
            List<TimeRecord> times = new List<TimeRecord>();
            times.Add(time);
            fill.FillFileGeneric(times, (int)Us.UserRole, true);
        }


        /// <summary>
        /// метод выводит отчет по всем сотрудникам за выбранный период (группируем по сотруднику)
        /// </summary>
        private static void WatchWorkerReport()
        {
            DateTime startdate;
            DateTime enddate;
            int itoghour = 0;
            decimal itogtotalpay = 0;
            do
            {
                Console.WriteLine("Введите дату начала отчета");
                var D = Console.ReadLine();
                if (String.IsNullOrEmpty(D))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(D, out startdate))
                {

                }
                else
                {
                    Console.WriteLine("Вы вводите некорректные данные");
                    continue;
                }
                Console.WriteLine("Введите дату окончания отчета");
                var DD = Console.ReadLine();
                if (String.IsNullOrEmpty(DD))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(DD, out enddate))
                {

                }
                else
                {
                    Console.WriteLine("Вы вводите некорректные данные");
                    continue;
                }
                if (enddate < startdate)
                {
                    Console.WriteLine("Вы  вводите некорректную дату");

                }
                else
                    break;
            }
            while (true);

            List<TimeRecord> allworkrep = new List<TimeRecord>();//создали новую общую коллекцию (пустая)
            for (int indexrole = 0; indexrole < 3; indexrole++)
            {
                List<TimeRecord> allwork = fill.ReadFileGeneric(indexrole);//вычитываем все файлы в коллекцию allwork
                allworkrep.AddRange(allwork);//добавляем группу элементов коллекции allwork в общую коллекцию allworkrep
            }


            Dictionary<string, List<TimeRecord>> workmap = new Dictionary<string, List<TimeRecord>>();//создаем новый словарь (пока пустой), в котором тип
                                                                                                      //Ключа строка(фильтруем по имени, так как
                                                                                                     // в нашем приложении оно уникально), тип Значения Список(List<>)

            foreach (var workitem in allworkrep)//перебираем общую коллекцию и каждый ее элемент кладем в переменную workitem
            {
                if (workitem.Date >= startdate && workitem.Date <= enddate)//фильтруем дату отчета
                    if (!workmap.ContainsKey(workitem.Name))//проверяем наличие Ключа, если его нет
                    {
                        workmap.Add(workitem.Name, new List<TimeRecord>());// то добавляем ключ, а значение пока еще пустое!!!
                        workmap[workitem.Name].Add(workitem);//после добавления ключа, добавляем Значение по вышедобавленному ключу
                    }
                    else//иначе ключ есть
                    {
                        workmap[workitem.Name].Add(workitem);//просто добавляем Значение по существующему ключу

                    }
            }

            foreach (var sortwork in workmap)
            {
                var rephour = fill.UserGet(sortwork.Key);//получаем имя-ключ из словаря и значение кладем в переменную rephour

                var HH = sortwork.Value;//значение из словаря положили в переменную HH
                if (rephour.UserRole == UserRole.Manager)//проверяем роль через имя
                {
                    var totp = new Manager(rephour, HH, startdate, enddate);//создаем новый экземпляр типа Manager
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepPerson();

                    Console.WriteLine($"Всего отработано {totp.sumhour}");//итоговое время по конкретному сотруднику
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");//итоговая зп по конкретному сотруднику
                    itoghour += totp.sumhour;//итоговое время по всем независимо от роли
                    itogtotalpay += totp.TotalPay;//итоговая з/п по всем независимо от роли


                }
                else if (rephour.UserRole == UserRole.Employee)
                {
                    var totp = new Employee(rephour, HH, startdate, enddate);
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepPerson();

                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");
                    itoghour += totp.sumhour;
                    itogtotalpay += totp.TotalPay;

                }
                else if (rephour.UserRole == UserRole.Frelanser)
                {
                    var totp = new Freelanser(rephour, HH, startdate, enddate);
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepPerson();

                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");
                    itoghour += totp.sumhour;
                    itogtotalpay += totp.TotalPay;

                }

            }
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Всего отработано {itoghour}");
            Console.WriteLine($"Всего заработано {itogtotalpay}");

            MenuUp();
        }

        /// <summary>
        /// метод выводит отчет по конкретному сотруднику
        /// </summary>
        private static void WatchWorkerHour()
        {
            DateTime startdate;
            DateTime enddate;
           
            do
            {
                Console.WriteLine("Введите дату начала отчета");
                var D = Console.ReadLine();
                if (String.IsNullOrEmpty(D))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(D, out startdate))
                {

                }
                else
                {
                    Console.WriteLine("Вы вводите некорректные данные");
                    continue;
                }
                Console.WriteLine("Введите дату окончания отчета");
                var DD = Console.ReadLine();
                if (String.IsNullOrEmpty(DD))
                {
                    Console.WriteLine("Дата должна быть введена!");
                }
                if (DateTime.TryParse(DD, out enddate))
                {

                }
                else
                {
                    Console.WriteLine("Вы вводите некорректные данные");
                    continue;
                }

                if (enddate < startdate)
                {
                    Console.WriteLine("Вы  вводите некорректную дату");

                }
                else
                    break;
            }
            while (true);

            User rephour;
            do
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Введите пользователя");


                string inputstring = Console.ReadLine();
                Console.WriteLine("---------------------");
                rephour = fill.UserGet(inputstring);

                if (rephour == null)
                {
                    Console.WriteLine("Пользователь не существует");
                }
                else
                {
                    break;
                }
            }
            while (true);

            var HH = fill.ReadFileGeneric((int)rephour.UserRole);
            if (rephour.UserRole == UserRole.Manager)
            {
                var totp = new Manager(rephour, HH, startdate, enddate);
                totp.PrintRepPerson();
                Console.WriteLine($"Всего отработано {totp.sumhour}");
                Console.WriteLine($"Всего заработано {totp.TotalPay}");

                Console.ReadLine();
            }
            else if (rephour.UserRole == UserRole.Employee)
            {
                var totp = new Employee(rephour, HH, startdate, enddate);
                totp.PrintRepPerson();
                Console.WriteLine($"Всего отработано {totp.sumhour}");
                Console.WriteLine($"Всего заработано {totp.TotalPay}");

                Console.ReadLine();
            }
            else if (rephour.UserRole == UserRole.Frelanser)
            {
                var totp = new Freelanser(rephour, HH, startdate, enddate);
                totp.PrintRepPerson();
                Console.WriteLine($"Всего отработано {totp.sumhour}");
                Console.WriteLine($"Всего заработано {totp.TotalPay}");


            }
            MenuUp();

        }

        private static void MenuUp()
        {
            int choice;
            Console.WriteLine("Выберите действие  \n " +
                          "Введите 1, если вы хотите продолжить \n " +
                          "Введите 2, если вы хотите выйти из меню");


            if (Int32.TryParse(Console.ReadLine(), out choice))
                if (choice == 1)
                {
                    if (polzovatel.UserRole == UserRole.Manager)
                    {
                        Showmanagermenu();
                    }
                    if (polzovatel.UserRole == UserRole.Frelanser)
                    {
                        Showfrilansermenu();
                    }
                    if (polzovatel.UserRole == UserRole.Employee)
                    {
                        Showemployeemenu();
                    }

                }
                else if (choice == 2)
                {
                    Environment.Exit(0);

                }
                else
                    Console.WriteLine("Вы выбрали несуществующее действие");
            Environment.Exit(0);

        }
       
private static void AddWorkerHour()
        {
            User worker;
            DateTime date;
            Console.WriteLine("*************************************************");
            Console.WriteLine("Введите пользователя");
            string name = Console.ReadLine();
            worker = fill.UserGet(name);
            do
            {
                if (worker == null)
                {
                    Console.WriteLine("Пользователь не существует");
                    return;
                }

                Console.WriteLine("Введите дату");
                var DD = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(DD) && DateTime.TryParse(DD, out date))
                {


                }
                else
                {
                    Console.WriteLine("Введенная дата неверная!");
                    continue;

                }
                
                Console.WriteLine("Введите отработанное время");
                if (Int32.TryParse(Console.ReadLine(), out int H))
                {
                    
                    AddHourWithControleDate(worker, H, date);
                }
                MenuUp();
            }
            while (true);
           
        }

        private static void AddWorker()
        {
            Console.WriteLine("Введите имя пользователя");
            string userName = Console.ReadLine();
            User M = fill.UserGet(userName);
            if(M == null)
            {

            }
            else
            {
                Console.WriteLine("Такой пользователь существует!");
                MenuUp();
            }
            Console.WriteLine("Введите роль пользователя");
            var IR = InputRole();
            var user = new User(userName, IR);
            List<User> users = new List<User>();
            users.Add(user);
            fill.FillFileUser(users, true);
           
            Dictionary<UserRole, List<string>> groupworkrep = new Dictionary<UserRole, List<string>>();

            var groupuser = fill.ReadFileUser();
            foreach (var groupitem in groupuser)
            {
                if (!groupworkrep.ContainsKey(groupitem.UserRole))//проверяем наличие Ключа, если его нет
                {
                    groupworkrep.Add(groupitem.UserRole, new List<string>());// то добавляем ключ, а значение пока еще пустое!!!
                    groupworkrep[groupitem.UserRole].Add(groupitem.Name);//после добавления ключа, добавляем Значение по вышедобавленному ключу
                }
                else//иначе ключ есть
                {
                    groupworkrep[groupitem.UserRole].Add(groupitem.Name);//просто добавляем Значение по существующему ключу

                }
            }

           
            foreach (var groupwork in groupworkrep)
            {
           if (groupwork.Key == user.UserRole)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(groupwork.Key);
                    Console.WriteLine("-------------------------");
                }
                if (groupwork.Key == user.UserRole)
                    foreach (var item in groupwork.Value)
                {

                    Console.WriteLine(item);

                }
            }
            Console.WriteLine("-------------------------");
            MenuUp();
        }
    }
}



