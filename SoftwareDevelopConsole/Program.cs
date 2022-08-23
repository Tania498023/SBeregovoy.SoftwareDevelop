using NPOI.SS.Formula.Functions;
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
        private static UserRole enteruser;
        static FileRepository fill;
        private static User polzovatel;


        //public static DateTime enddate;
        //public static DateTime startdate;

        static void Main(string[] args)

        {
            int userRole = 0;

            fill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            fill.FillFileUser(userreturn.Users(), false);//вызываем методы FillFileUser и Users


            var genericreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            fill.FillFileGeneric(genericreturn.Generic(), userRole, false);//вызываем методы FillFileEmployee и Employees

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
            do
            {
                Console.WriteLine("Введите роль \n Введите 0, если менеджер \n Введите 1, если сотрудник \n Введите 2, если фрилансер");
                int controleRole = Convert.ToInt32(Console.ReadLine());

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
                    "Введите 4, если вы хотите посмотреть часы работы сотрудника");

                actionmanager = Convert.ToInt32(Console.ReadLine());

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
                else
                    Console.WriteLine("Вы выбрали несуществующее действие");
            }

            while (actionmanager < 1 || actionmanager > 4);//доделать для каждого меню, реализовать методы
        }
        private static void Showemployeemenu()
        {
            int actionemployee;
            do
            {
                Console.WriteLine("Выберите действие  \n " +
                    "Введите 1, если вы хотите ввести часы \n " +
                    "Введите 2, если вы хотите просмотреть часы");

                actionemployee = Convert.ToInt32(Console.ReadLine());

                if (actionemployee == 1)
                {
                    AddEmployeeHour();
                    break;
                }
                else if (actionemployee == 2)
                {
                    WatchEmployeeHour();
                    break;
                }
                else
                    Console.WriteLine("Вы выбрали несуществующее действие");
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

                actionfrilanser = Convert.ToInt32(Console.ReadLine());

                if (actionfrilanser == 1)
                {
                    AddFrilanserHour();
                    break;
                }
                else if (actionfrilanser == 2)
                {
                    WatchFrilanserHour();
                    break;
                }
                else
                    Console.WriteLine("Вы выбрали несуществующее действие");
            }

            while (actionfrilanser < 1 || actionfrilanser > 2);
        }

        private static void WatchFrilanserHour()
        {
            WatchHour();
        }

        private static void WatchHour()
        {
            var HH = fill.ReadFileGeneric((int)polzovatel.UserRole);//!!!метод вернул коллекцию, сохранили в переменную
            foreach (var item in HH)//перебираем коллекцию HH, выбираем нужное и сохраняем в переменную item
            {

                if (item.Name == polzovatel.Name)//если элемент из коллекции совпадает по имени с пользователем, выводим на консоль
                    Console.WriteLine(item.Date.ToString() + "\t" + item.Name + "\t" + item.Hours + "\t" + item.Message);

            }
            Console.ReadLine();
        }

        private static void AddFrilanserHour()
        {
            AddHour();
        }

        private static void AddHour()
        {
            int H;
            do
            {
                Console.WriteLine("Введите отработанное время");
                H = Convert.ToInt32(Console.ReadLine());
                if (H <= 0 || H >= 24)
                {
                    Console.WriteLine("Вы вводите некорректные данные");

                }
                else
                {
                    Console.WriteLine("Введите сообщение");
                    string mas = Console.ReadLine();
                    var time = new TimeRecord(DateTime.Now, polzovatel.Name, H, mas);
                    List<TimeRecord> times = new List<TimeRecord>();
                    times.Add(time);
                    fill.FillFileGeneric(times, (int)polzovatel.UserRole, true);
                }

            }
            while (H <= 0 || H >= 24);
        }

        private static void WatchEmployeeHour()
        {
            WatchHour();
        }

        private static void AddEmployeeHour()
        {
            AddHour();
        }

        private static void WatchWorkerReport()//по все сотрудникам за выбранный период (группируем по сотруднику)
        {
            DateTime startdate;
            DateTime enddate;
            int itoghour = 0;
            decimal itogtotalpay = 0;
            do
            {
                Console.WriteLine("Введите дату начала отчета");
                startdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Введите дату окончания отчета");
                enddate = Convert.ToDateTime(Console.ReadLine());

                if (enddate < startdate)
                {
                    Console.WriteLine("Вы  вводите некорректную дату");

                }
                else
                    break;
            }
            while (true);

            List<TimeRecord> allworkrep= new List<TimeRecord>();//создали новую общую коллекцию (пустая)
            for(int i = 0; i < 3; i++)
            {
                var allwork = fill.ReadFileGeneric(i);//вычитываем все файлы в коллекцию allwork
                allworkrep.AddRange(allwork);//добавляем группу элементов коллекции allwork в общую коллекцию allworkrep
            }

            
            Dictionary<string, List<TimeRecord>> workmap = new Dictionary<string, List<TimeRecord>>();//создаем новый словарь (пока пустой), в котором тип
                                                                                                      //Ключа строка(фильтруем по имени, так как
                                                                                                      //в нашем приложении оно уникально), тип Значения
                                                                                                      // Список(List<>)
            foreach(var workitem in allworkrep)//перебираем общую коллекцию и каждый ее элемент кладем в переменную workitem
            {
                if (workitem.Date >= startdate && workitem.Date <= enddate)//фильтруем дату отчета
                    if ( !workmap.ContainsKey(workitem.Name))//проверяем наличие Ключа, если его нет
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
                
                
                //просмотреть ТЗ, что еще не доделали

                var HH = sortwork.Value;//значение из словаря положили в переменную HH
                if (rephour.UserRole == UserRole.Manager)//проверяем роль через имя
                {
                    var totp = new Manager(rephour.Name, HH, startdate, enddate);//создаем новый экземпляр типа Manager
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepManager();//у экземпляра вызываем метод PrintRepManager

                    Console.WriteLine($"Всего отработано {totp.sumhour}");//итоговое время по конкретному сотруднику
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");//итоговая зп по конкретному сотруднику
                    itoghour += totp.sumhour;//итоговое время по всем независимо от роли
                    itogtotalpay += totp.TotalPay;//итоговая з/п по всем независимо от роли


                }
                else if (rephour.UserRole == UserRole.Employee)
                {
                    var totp = new Employee(rephour.Name, HH, startdate, enddate);
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepEmployee();
                    
                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");
                    itoghour += totp.sumhour;
                    itogtotalpay += totp.TotalPay;

                }
                else if (rephour.UserRole == UserRole.Frelanser)
                {
                    var totp = new Frilanser(rephour.Name, HH, startdate, enddate);
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Сотрудник {sortwork.Key}");
                    totp.PrintRepFrilanser();
                    
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
            Console.ReadLine();
        }

            private static void WatchWorkerHour()//часы по конкретному сотруднику
            {
                DateTime startdate;
                DateTime enddate;
                
                do
                {
                    Console.WriteLine("Введите дату начала отчета");
                    startdate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите дату окончания отчета");
                    enddate = Convert.ToDateTime(Console.ReadLine());

                    if (enddate < startdate)
                    {
                        Console.WriteLine("Вы  вводите некорректную дату");

                    }
                    else
                        break;
                }
                while (true);


                Console.WriteLine("Введите пользователя");

                string inputstring = Console.ReadLine();
                var rephour = fill.UserGet(inputstring);

                if (rephour == null)
                {
                    Console.WriteLine("Пользователь не существует");
                }

                var HH = fill.ReadFileGeneric((int)rephour.UserRole);
                if (rephour.UserRole == UserRole.Manager)
                {
                    var totp = new Manager(rephour.Name, HH, startdate, enddate);
                    totp.PrintRepManager();
                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");

                    Console.ReadLine();
                }
                else if (rephour.UserRole == UserRole.Employee)
                {
                    var totp = new Employee(rephour.Name, HH, startdate, enddate);
                    totp.PrintRepEmployee();
                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");

                    Console.ReadLine();
                }
                else if (rephour.UserRole == UserRole.Frelanser)
                {
                    var totp = new Frilanser(rephour.Name, HH, startdate, enddate);
                    totp.PrintRepFrilanser();
                    Console.WriteLine($"Всего отработано {totp.sumhour}");
                    Console.WriteLine($"Всего заработано {totp.TotalPay}");

                    Console.ReadLine();
                }

            }

            private static void AddWorkerHour()
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("Введите пользователя");
                string name = Console.ReadLine();
                polzovatel = fill.UserGet(name);

                if (polzovatel == null)
                {
                    Console.WriteLine("Пользователь не существует");//некорректная проверка
                    return;
                }

                Console.WriteLine("Введите отработанное время");
                int H = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите сообщение");
                string mas = Console.ReadLine();
                var time = new TimeRecord(DateTime.Now, polzovatel.Name, H, mas);
                List<TimeRecord> times = new List<TimeRecord>();
                times.Add(time);
                fill.FillFileGeneric(times, (int)polzovatel.UserRole, true);

            }

            private static void AddWorker()
            {
                Console.WriteLine("Введите имя пользователя");
                string N = Console.ReadLine();
                Console.WriteLine("Введите роль пользователя");
                var IR = InputRole();
                var user = new User(N, IR);
                List<User> users = new List<User>();
                users.Add(user);
                fill.FillFileUser(users, true);

            }
        }
    }



