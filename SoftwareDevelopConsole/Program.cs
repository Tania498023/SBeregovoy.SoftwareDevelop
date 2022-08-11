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
        private static bool users;

        static void Main(string[] args)

        {
            int userRole = 0;

            fill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            fill.FillFileUser(userreturn.Users(), false);//вызываем методы FillFileUser и Users
            

            var genericreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            fill.FillFileGeneric(genericreturn.Generic(), userRole, false);//вызываем методы FillFileEmployee и Employees

            var text = fill.ReadFileUser();
            
            ControlRole();
        }
        public static void ControlRole()//контроль вводимой роли при входе в программу
        {
           var IR = InputRole();

            DisplayMenu(IR);
        }

        private static UserRole InputRole()
        {
            do
            {
                Console.WriteLine("Введите роль \n Введите 0, если вы менеджер \n Введите 1, если вы сотрудник \n Введите 2, если вы фрилансер");
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
                //Console.WriteLine(" ");
                //int controleRole = Convert.ToInt32(Console.ReadLine());

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

            while (actionemployee < 1 || actionemployee > 2);//доделать для каждого меню, реализовать методы
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

            while (actionfrilanser < 1 || actionfrilanser > 2);//реализовать методы
        }

        private static void WatchFrilanserHour()
        {
            throw new NotImplementedException();
        }

        private static void AddFrilanserHour()
        {
            throw new NotImplementedException();
        }

        private static void WatchEmployeeHour()//только по себе? делать для сотрудика и фрилансера отдельно или разграничить условиями
        {
            throw new NotImplementedException();
        }

        private static void AddEmployeeHour()
        {
            throw new NotImplementedException();
        }

        private static void WatchWorkerReport()
        {
            throw new NotImplementedException();
        }

        private static void WatchWorkerHour()//по всем сотрудникам
        {
            throw new NotImplementedException();
        }

        private static void AddWorkerHour()
        {
            throw new NotImplementedException();
        }

        private static void AddWorker()
        {
            Console.WriteLine("Введите имя пользователя");
            string N = Console.ReadLine();
            Console.WriteLine("Введите роль пользователя");
            var IR = InputRole();
            var user = new User(N,IR);
            List<User> users = new List<User>();
            users.Add(user);
            fill.FillFileUser(users, true);
            
        }
    }
}


