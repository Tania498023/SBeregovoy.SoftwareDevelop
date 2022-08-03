using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Frilanser : Person
    {
        public decimal TotalPay { get; }
        
        public Frilanser(string name, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
            decimal totalPay = 0;
            foreach (var timeRecord in timeRecords)
            {
                totalPay += Settings.payPerHour * timeRecord.Hours;
            }

            return;//доделать зп
            

        }
        

    }


    
    
    
}

