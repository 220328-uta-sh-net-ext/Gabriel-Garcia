using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class MainMenu : IMenu
    {
        public void DisplayStartMenu()
        {
            Console.WriteLine("Welcome to Restaurant Review");
            Console.WriteLine("Create User:\t 2");
            Console.WriteLine("Login User:\t 1");
            Console.WriteLine("Exit:\t\t 0");
        }
        public void DisplayUserMenu()
        {
            Console.WriteLine("This is User Menu");
        }
        public void DisplayAdminMenu()
        {
            Console.WriteLine("This is Admin Menu");
        }
       
        public string UserChoiceLogingin()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
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
        public string UserChoiceLogedin()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "DeleteAccount";
                case "2":
                    Console.Clear();
                    return "Restaurant as User";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "UserMenu";
            }
        }
        public string AdminUserLoggin()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Print User Info";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
            }
        }
        public string RestaurantRevMenu()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Print User Info";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
            }
        }
        public string RestaurantRequest()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Print User Info";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
            }
        }
        public string MyReviewedRestaurant()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Print User Info";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
            }
        }
    }
}
