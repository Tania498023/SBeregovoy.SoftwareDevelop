using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBeregovoy.SoftwareDevelop.Domain;




namespace SBeregovoy.SoftwareDevelop.Persistence
{
    public class MemoryRepository : IRepository

    {
        #region Fake Data
        private List<TimeRecord> emloyees = new List<TimeRecord>()
        {
                new TimeRecord(DateTime.Now.AddDays(-3),"Иванов",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Васильев",8,"test message 2"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Иванов",10,"test message 3"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Васильев",8,"test message 4"),
        };

        private List<TimeRecord> frilanser = new List<TimeRecord>()
        {
                new TimeRecord(DateTime.Now.AddDays(-3),"Смит",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-3),"Бонд",8,"test message 2"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Смит",10,"test message 3"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Бонд",8,"test message 4"),

        };
        private List<TimeRecord> manager = new List<TimeRecord>()
        {
                new TimeRecord(DateTime.Now.AddDays(-3),"Береговой",8,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-2),"Береговой",10,"test message 2"),
        };
        private List<User> users = new List<User>()
             {
                new User("Иванов", UserRole.Employee),
                new User("Васильев", UserRole.Employee),
                new User("Смит", UserRole.Frelanser),
                new User("Бонд", UserRole.Frelanser),
                new User("Береговой", UserRole.Manager),
             }; 
        #endregion
        public List<TimeRecord> Employees()
        {
            return emloyees;
        }
        public List<TimeRecord> Frilanser()
        {
            return frilanser;
        }
        public List<TimeRecord> Manager()
        {
            return manager;
        }
        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = new List<TimeRecord>();
            switch (userRole)
            {
                case UserRole.Manager:
                    records = Manager();
                    break;
                case UserRole.Employee:
                    records = Employees();
                    break;
                case UserRole.Frelanser:
                    records = Frilanser();
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
            if(from == null)
            {
                from = DateTime.Now.AddYears(-100);
            }
            if(to == null)
            {
                to = DateTime.Now;
            }

            return records.Where(x=>from.Value >= x.Date && x.Date <= to).ToList();
        }
        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x=>x.Name == userName).ToList();
        }
        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            switch (userRole)
            {
                case UserRole.Manager:
                    manager.Add(timeRecord);
                    break;
                case UserRole.Employee:
                    emloyees.Add(timeRecord);
                    break;
                case UserRole.Frelanser:
                   frilanser.Add(timeRecord);
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
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
         public List<User> Users()
         {  
            return users;
            
         }
    }
}
