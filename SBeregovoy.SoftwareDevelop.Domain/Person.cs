using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Hoursworked { get; set; }

        public Person(string name, decimal salary, int hoursworked)
        {
            Name = name;
            Salary = salary;
            Hoursworked = hoursworked;
        }
        public class Manager 

        {
            decimal oklad = 200000;
            decimal premia = 20000;
            int hours = 158;
            int fullhours = 160;

            public void RaschetSalary(decimal oklad, int hours, decimal premia)
            {
                
            }
        }
    }

}
