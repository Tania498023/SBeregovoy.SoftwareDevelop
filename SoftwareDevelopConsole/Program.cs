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

            var userfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileUser
            var userreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Users
            userfill.FillFileUser(userreturn.Users(),false);//вызываем методы FillFileUser и Users

            var genericfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileGeneric
            var genericreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Employees
            genericfill.FillFileGeneric(genericreturn.Generic(), userRole, false);//вызываем методы FillFileEmployee и Employees

            //var frilanserfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileFrilanser
            //var frilanserreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Frilanser
            //frilanserfill.FillFileFrilanser(frilanserreturn.Frilanser());//вызываем методы FillFileFrilanser и Frilanser

            //var managerfill = new FileRepository();//создаем экземпляры для возможности вызова метода FillFileManager
            //var managerreturn = new MemoryRepository();//создаем экземпляры для возможности вызова метода Manager
            //managerfill.FillFileManager(managerreturn.Manager());//вызываем методы FillFileManager и Manager


        }
    }
}

