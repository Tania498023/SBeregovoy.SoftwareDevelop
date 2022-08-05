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
        static void Main(string[] args)

        {
            int userRole = 0;

            var fill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            fill.FillFileUser(userreturn.Users(),false);//вызываем методы FillFileUser и Users

            
            var genericreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            fill.FillFileGeneric(genericreturn.Generic(), userRole, false);//вызываем методы FillFileEmployee и Employees

            var text = fill.ReadFileUser();


        }
    }
}

