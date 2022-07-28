using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBeregovoy.SoftwareDevelop.Domain;




namespace SBeregovoy.SoftwareDevelop.Persistence
{
    public class MemoryRepository : IRepository

    {
        public List<TimeRecord> Employees()
        {
            return new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.AddDays(-3),"Иванов",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Васильев",8,"test message 2"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Иванов",10,"test message 3"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Васильев",8,"test message 4"),
            };
        }
        public List<TimeRecord> Frilanser()
        {
            return new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.AddDays(-3),"Смит",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Бонд",8,"test message 2"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Смит",10,"test message 3"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Бонд",8,"test message 4"),
            };
        }

        public List<TimeRecord> Manager()
        {
            return new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.AddDays(-3),"Береговой",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Береговой",10,"test message 2"),
                
            };
        }

        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            throw new NotImplementedException();
        }

        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            throw new NotImplementedException();
        }

        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            throw new NotImplementedException();
        }

        public bool UserCreate(UserRole userRole, string name)
        {
           var newUser = new User(name, userRole);
            User existedUser = UserGet(name);
            if (existedUser == null)
            {
                users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User UserGet(string name)
        {
            foreach(var record in Users())
            {
                if (record.Name == name)
                    return record;
            }
            return null;
        }
        private List<User> users = new List<User>()
             {
                new User("Иванов", UserRole.Employee),
                new User("Васильев", UserRole.Employee),
                new User("Смит", UserRole.Frelanser),
                new User("Бонд", UserRole.Frelanser),
                new User("Береговой", UserRole.Manager),
             };
        public List<User> Users()
        {
            return users;
            
        }
    }
}
