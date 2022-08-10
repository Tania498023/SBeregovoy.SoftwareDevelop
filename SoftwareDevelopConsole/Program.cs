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

        static void Main(string[] args)

        {
            int userRole = 0;

            var fill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            fill.FillFileUser(userreturn.Users(), false);//вызываем методы FillFileUser и Users


            var genericreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            fill.FillFileGeneric(genericreturn.Generic(), userRole, false);//вызываем методы FillFileEmployee и Employees

            var text = fill.ReadFileUser();
            
            ControlRole();
        }
        public static void ControlRole()//контроль вводимой роли при входе в программу
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


            }while (enteruser >= UserRole.Manager && enteruser <= UserRole.Frelanser);

            DisplayMenu(enteruser);
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
                    Showmenegermenu();
                    break;
                }
                if (userRole == UserRole.Employee)
                {
                    Console.WriteLine("Меню Сотрудник");
                    
                    break;
                }
                if (userRole == UserRole.Frelanser)
                {
                    Console.WriteLine("Меню Фрилансер");
                   
                    break;
                }

            }
            while (true);
            
        }

        private static void Showmenegermenu()
        {
            int actionnumber;
            do
            {
                Console.WriteLine("Выберите действие  \n " +
                    "Введите 1, если вы хотите добавить сотрудника \n " +
                    "Введите 2, если вы хотите добавить время сотруднику \n " +
                    "Введите 3, если вы хотите посмотреть отчет по всем сотрудникам (возможность выбрать период)"+
                    "Введите 4, если вы хотите посмотреть часы работы сотрудника");

                actionnumber = Convert.ToInt32(Console.ReadLine());

                if (actionnumber == 1)
                {
                    AddEmployee();
                    break;
                }
                else if (actionnumber == 2)
                {
                    AddEmployeeHour();
                    break;
                }
                else if (actionnumber == 3)
                {

                    WatchEmployeeReport();
                    break;
                }
                else if (actionnumber == 4)
                {

                    WatchEmployeeHour();
                    break;
                }
                else
                    Console.WriteLine("Вы выбрали несуществующее действие");
            }

            while (actionnumber >= 1 && actionnumber <= 4);// проверить условие, доделать для каждого меню, реализовать методы
        }

        private static void WatchEmployeeReport()
        {
            throw new NotImplementedException();
        }

        private static void WatchEmployeeHour()
        {
            throw new NotImplementedException();
        }

        private static void AddEmployeeHour()
        {
            throw new NotImplementedException();
        }

        private static void AddEmployee()
        {
            throw new NotImplementedException();
        }
    }
}


