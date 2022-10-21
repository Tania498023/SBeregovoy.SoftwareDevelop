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
        /// константы(количество рабочих часов и стоимость часа)
        /// </summary>
        public const byte WorkHoursInMonth = 160;
        public const byte WorkHourInDay = 8;
        public const decimal payPerHour = 1000;
    }
}
