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
            Console.WriteLine("Rate a Restaurant:\t 3");
            Console.WriteLine("Restaurant's Review:\t 2");
            Console.WriteLine("Restaurant's Detail:\t 1");
            Console.WriteLine("Exit:\t\t 0");
        }
        public void DisplayAdminMenu()
        {
            Console.WriteLine("This is Admin Menu");
            Console.WriteLine("See All User:\t 6");
            Console.WriteLine("Search User:\t 5");
            Console.WriteLine("Restaurant's Detail:\t 4");
            Console.WriteLine("Restaurant's Review:\t 3");
            Console.WriteLine("Rate a Restaurant:\t 2");
            Console.WriteLine("Add a Restaurant:\t 1");
            Console.WriteLine("Exit:\t\t 0");
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
                    return "Rate a Restaurant";
                case "2":
                    Console.Clear();
                    return "Restaurant's Review";
                case "3":
                    Console.Clear();
                    return "Restaurant's Detail";
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
                    return "Add a Restaurant";
                case "2":
                    Console.Clear();
                    return "Rate a Restaurant";
                case "3":
                    Console.Clear();
                    return "Restaurant's Review";
                case "4":
                    Console.Clear();
                    return "Restaurant's Detail";
                case "5":
                    Console.Clear();
                    return "Search User";
                case "6":
                    Console.Clear();
                    return "See All User";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "AdminMenu";
            }
        }

    }
}
