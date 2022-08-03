using NUnit.Framework;
using SBeregovoy.SoftwareDevelop.Domain;
using System;
using System.Collections.Generic;

namespace SBeregovoy.SoftwareDevelop.SoftwareDevelopTests
{
    public class PersonsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ManagerTotalPay()
        {
            //10000+11000+8750=29750
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"test",8,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"test",9,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-1),"test",7,"test message"),
            });

               Assert.IsTrue(manager.TotalPay == 29750);
        }
        [Test]
        public void ManagerTotalPay2()
        {
            //10000
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"test",8,"test message"),

            });

            Assert.IsTrue(manager.TotalPay == 10000);
        }
        [Test]
        public void FrilanserTotalPay()
        {
            //
            Frilanser frilanser = new Frilanser("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"test",8,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"test",9,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-1),"test",7,"test message"),
            });

            Assert.IsTrue(frilanser.TotalPay == 24000);
        }
    }
}