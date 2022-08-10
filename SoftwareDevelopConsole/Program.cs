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
                }

            while (enteruser >= UserRole.Manager && enteruser <= UserRole.Frelanser);
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
                    Console.WriteLine("1. добавить сотрудника");
                    Console.WriteLine("2. добавить время сотруднику");
                    Console.WriteLine("3. посмотреть отчет по всем сотрудникам (возможность выбрать период)");
                    Console.WriteLine("4. посмотреть часы работы сотрудника");
                    break;
                }
                if (userRole == UserRole.Employee)
                {
                    Console.WriteLine("Меню Сотрудник");
                    Console.WriteLine("1. ввести часы");
                    Console.WriteLine("2. просмотреть часы");
                    break;
                }
                if (userRole == UserRole.Frelanser)
                {
                    Console.WriteLine("Меню Фрилансер");
                    Console.WriteLine("1. ввести часы");
                    Console.WriteLine("2. просмотреть часы");
                    break;
                }

            }
            while (true);
            
        }
    }
}


