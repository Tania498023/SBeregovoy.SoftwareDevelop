using NUnit.Framework;
using SBeregovoy.SoftwareDevelop.Persistence;
using System.Linq;
using System.Collections.Generic;
using SBeregovoy.SoftwareDevelop.Domain;

namespace SBeregovoy.SoftwareDevelop.SoftwareDevelopTests
{
    public class RepositoryTests
    {
        IRepository memoryRepository = new MemoryRepository();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserCreateEmployee()
        {
            bool isCreate = memoryRepository.UserCreate(Domain.UserRole.Employee, "������");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "������");
            Assert.IsTrue(isCreate);
            Assert.IsTrue(newUser!=null);
            Assert.IsTrue(newUser.UserRole == Domain.UserRole.Employee);
               
        }
        [Test]
        public void UserCreateEmployeeExisted()
        {
            bool isCreate = memoryRepository.UserCreate(Domain.UserRole.Employee, "������");
            var existedUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "������");
            Assert.IsTrue(!isCreate);
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(existedUser.UserRole == Domain.UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("������");
            var notexistedUser = memoryRepository.UserGet("�����");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notexistedUser == null);
           
        }
        [Test]
        public void ReportGetByUserEmployeeTest()
        {
            var reportList = memoryRepository.ReportGetByUser("��������",UserRole.Employee,null,null);
            var sampleList = new List<TimeRecord>() 
            {
            new TimeRecord(DateTime.Now.Date.AddDays(-3),"��������",8,"test message 2"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2),"��������",8,"test message 4"),
            };
          
            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));

        }
        [Test]
        public void ReportGetByUserManagerTest()
        {
            var reportList = memoryRepository.ReportGetByUser("���������", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
            new TimeRecord(DateTime.Now.Date.AddDays(-3),"���������",8,"test message 1"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2),"���������",10,"test message 2"),
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));

        }
    }
}