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
            bool isCreate = memoryRepository.UserCreate(Domain.UserRole.Employee, "Тестов");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "Тестов");
            Assert.IsTrue(isCreate);
            Assert.IsTrue(newUser!=null);
            Assert.IsTrue(newUser.UserRole == Domain.UserRole.Employee);
               
        }
        [Test]
        public void UserCreateEmployeeExisted()
        {
            bool isCreate = memoryRepository.UserCreate(Domain.UserRole.Employee, "Иванов");
            var existedUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "Иванов");
            Assert.IsTrue(!isCreate);
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(existedUser.UserRole == Domain.UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("Иванов");
            var notexistedUser = memoryRepository.UserGet("Буков");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notexistedUser == null);
           
        }
        [Test]
        public void ReportGetByUserEmployeeTest()
        {
            var reportList = memoryRepository.ReportGetByUser("Васильев",UserRole.Employee,null,null);
            var sampleList = new List<TimeRecord>() 
            {
            new TimeRecord(DateTime.Now.Date.AddDays(-3),"Васильев",8,"test message 2"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2),"Васильев",8,"test message 4"),
            };
          
            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));

        }
        [Test]
        public void ReportGetByUserManagerTest()
        {
            var reportList = memoryRepository.ReportGetByUser("Береговой", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
            new TimeRecord(DateTime.Now.Date.AddDays(-3),"Береговой",8,"test message 1"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2),"Береговой",10,"test message 2"),
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));

        }
    }
}