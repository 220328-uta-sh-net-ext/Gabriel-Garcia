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
            Console.WriteLine("This is Start Menu");
            Console.WriteLine(" 0 - 1 - 2 options");
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
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
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
                    return "Print User Info";
                case "2":
                    Console.Clear();
                    return "Request to add a restaurant";
                case "3":
                    Console.Clear();
                    return "Review a Restaurant";
                case "4":
                    Console.Clear();
                    return "Reviewed Restaurants";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
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
