using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsUser
{
    internal class User
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }

        public User()
        {
            FirstName = string.Empty;
            MidName = string.Empty;
            LastName = string.Empty; 
            UserName = string.Empty;
            UserPassword = string.Empty;
            UserEmail = string.Empty;            
        }
        public override string ToString()
        {
            return $"Name:{FirstName} {MidName} {LastName}\nUser: {UserName}\nEmail:{UserEmail}";
        }
    }
}
