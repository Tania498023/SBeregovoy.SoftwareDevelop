using System;
using System.Collections.Generic;
using SBeregovoy.SoftwareDevelop.Domain;


namespace SBeregovoy.SoftwareDevelop.Persistence
{
    //логика работы с файлом
    public interface IRepository
    {
        List<User> Users();
        bool UserCreate(UserRole userRole, string name); 
        User UserGet(string name);

        void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord);
        List<TimeRecord> ReportGet (UserRole userRole, DateTime? from = null, DateTime? to = null);
        List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null);

        List<TimeRecord> Employees();
        List<TimeRecord> Manager();
        List<TimeRecord> Frilanser();
    }
}
