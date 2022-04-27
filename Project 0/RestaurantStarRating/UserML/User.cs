using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UserML
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }


        public User()
        {
            FirstName = "";
            LastName = "";
            UserName = "";
            ID = "";
            Password = "";
        }
        public override string ToString()
        {
            return $"First Name:{FirstName}\nLast Name:{LastName}\nUser Name:{UserName}\nUser ID:{ID}\nPassword:{Password}";
        }
    }
}