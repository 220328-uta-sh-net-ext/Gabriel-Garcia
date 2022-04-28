using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class UserMenuAdmin : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Admin Menu ");
            Console.WriteLine("<3>Add a Restaurant: ");
            Console.WriteLine("<2>Find a Restaurant: ");
            Console.WriteLine("<1>Find a User: ");
            Console.WriteLine("<0>Exit: ");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "FindUser";
                case "2":
                    return "FindRestaurant";
                case "3":
                    return "Add Restaurant";
                case "4":
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