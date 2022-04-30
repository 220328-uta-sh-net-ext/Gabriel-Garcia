using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class UserMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("User Menu ");
            Console.WriteLine("<2> Add a Review");
            Console.WriteLine("<1> See Resaurants");
            Console.WriteLine("<0> Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "User Menu";
                case "2":
                    return "User Menu";
                case "3":
                    return "User Menu";
                default:
                    Console.WriteLine("Please enter a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "Login User";
            }
        }        
    }
}
