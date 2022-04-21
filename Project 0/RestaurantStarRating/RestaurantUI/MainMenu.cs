using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class MainMenu : Menu
    {
        public void Display()
        {
            Console.WriteLine("Create new User");
            Console.WriteLine("Login User");
            Console.WriteLine("Exit");
        }

        public string UserChoice()
        {
            string sUserInput = Console.ReadLine();
            switch(sUserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "New User";
                case "2":
                    Console.Clear();
                    return "Loggin";
                case "3":
                    Console.Clear();
                    return "MainMenu";
                case "4":
                    Console.Clear();
                    return "PrintRestaurantList";
                default:
                    Console.WriteLine($"Your input '{sUserInput}' is invalid input");
                    Console.WriteLine($"do things...");
                    Console.WriteLine($"Would you like to exit");
                    return "MainMenu";
            }
        }
    }
}
