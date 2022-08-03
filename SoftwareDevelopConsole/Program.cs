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
            var userfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            userfill.FillFileUser(userreturn.Users());//вызываем методы FillFileUser и Users

            var employeefill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileEmployee
            var employeereturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            employeefill.FillFileEmployee(employeereturn.Employees());//вызываем методы FillFileEmployee и Employees

            var frilanserfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileFrilanser
            var frilanserreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Frilanser
            frilanserfill.FillFileFrilanser(frilanserreturn.Frilanser());//вызываем методы FillFileFrilanser и Frilanser

            
            
        }
    }
}

