using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBeregovoy.SoftwareDevelop.Domain
{
    public class User
    {
        public string Name { get; }
        public UserRole UserRole { get; }

        public User(string name, UserRole userRole)
        {
            Name = name;
            UserRole = userRole;
        }
    }


}
