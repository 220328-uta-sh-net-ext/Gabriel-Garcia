using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantML;

namespace RestaurantUI
{
    internal class AddRestaurant : IMenu
    {
        public static Restaurant newUser = new Restaurant();
        public void Display()
        {
        Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine("<5> Restaurant's Name: ");
            Console.WriteLine("<4> Country: ");
            Console.WriteLine("<3> State: " );
            Console.WriteLine("<2> Zip Code: ");
            Console.WriteLine("<1> Type's: ");
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
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "LoginMenu";
            }
        }
    }
}
