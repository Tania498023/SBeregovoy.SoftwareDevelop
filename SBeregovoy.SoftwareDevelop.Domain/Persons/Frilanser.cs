using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    internal class Frilanser : Person
    {
        public Frilanser(string name, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
        }
    }
}
}
