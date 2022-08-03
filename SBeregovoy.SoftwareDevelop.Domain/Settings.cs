using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public static class Settings
    {
        /// <summary>
        /// Количество рабочих часов в месяце
        /// </summary>
        public const byte WorkHoursInMonth = 160;
        public const byte WorkHourInDay = 8;
        public const decimal payPerHour = 1000;
    }
}
