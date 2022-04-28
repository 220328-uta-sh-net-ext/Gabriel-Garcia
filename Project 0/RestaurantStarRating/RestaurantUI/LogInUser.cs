using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBL;

namespace RestaurantUI
{
    internal class LogInUser : IMenu
    {
        private static string uName = "";
        private static string uPass = "";
        IUserLogic repo = new UserLogic();
        public void Display()
        {
            Console.WriteLine("Login menu");
            Console.WriteLine($"<3> User Name:{uName}");
            if(uPass == "")
                Console.WriteLine("<2> Password:");
            else
                Console.WriteLine("<2> Password: ***");
            Console.WriteLine($"<1> Login");
            Console.WriteLine("<0> Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    var result = repo.SearchUser(uName, uPass);
                    Console.Clear();
                    if (result == "Admin")
                        return "Admin Menu";
                    else if(result == "User")
                        return "User Menu";
                    else
                        Console.WriteLine("UserName or Password Invalid!");
                    return "Login User";
                case "2":
                    Console.WriteLine("Enter Password: ");
                    uPass = Console.ReadLine();
                    Console.Clear();
                    return "Login User";
                case "3":
                    Console.WriteLine("Enter UserName: ");
                    uName = Console.ReadLine();
                    Console.Clear();
                    return "Login User";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{userInput}' is invalid!");
                    return "Login User";
            }
        }
    }
}
