using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserML;

namespace RestaurantUI
{
    internal class AddUser : IMenu
    {
        public static User newUser = new User();
        public void Display()
        {
            Console.WriteLine("Adding a New Account\n");

            Console.WriteLine("<5> First Name: " + newUser.FirstName);
            Console.WriteLine("<4> Last Name: " + newUser.LastName);
            Console.WriteLine("<3> User Name: " + newUser.UserName);
            Console.WriteLine("<2> Password: ");
            Console.WriteLine("<1> Create Account");
            Console.WriteLine("<0> Go Back");
            Console.WriteLine();
        }

        public string UserChoice()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.Clear();
                    return "Loggin User";
                case "2":
                    Console.Clear();
                    return "Create User";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "LoginMenu";
            }
        }
    }
}
