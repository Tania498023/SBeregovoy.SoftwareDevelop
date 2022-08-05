using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class TimeRecord
    
    {
        public DateTime Date {get;}
        public string Name { get; }
        public int Hours { get; }
        public string Message { get; }

        public TimeRecord (DateTime date, string name, int hours, string message)
        {

            Date = date;
            Name = name;
            Hours = hours;
            Message = message;
        }
        public TimeRecord(string[] SSS)
        {
            Date = DateTime.Parse(SSS[0]);//строку конвертируем в DateTime
            Name = SSS[1];
            Hours = int.Parse(SSS[2]);//строку конвертируем в int
            Message = SSS[3];
        }
    }
}
