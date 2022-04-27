using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantML;
using RestaurantDL;

namespace RestaurantUI
{
    internal class AddRestaurant : IMenu
    {
        private static Restaurant newRestaurant = new Restaurant();
        private IRestaurantRepo _reposityory = new Restaurant();//up casting

        public void Display()
        {
        Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine("<6> Restaurant's Name: ");
            Console.WriteLine("<5> Country: ");
            Console.WriteLine("<4> State: " );
            Console.WriteLine("<3> Zipcode: ");
            Console.WriteLine("<2> Type's: ");
            Console.WriteLine("<1> Add Restaurant");
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
                    _reposityory.AddRestaurant(newRestaurant);
                    return "MainMenu";
                case "2":
                    Console.Write("Enter type: ");
                    newRestaurant.sType = Console.ReadLine();
                    return "AddRestaurant";
                case "3":
                    Console.Write("Enter Zipcode: ");
                    newRestaurant.sZipcode = Console.ReadLine();
                    return "AddRestaurant";
                case "4":
                    Console.Write("Enter State: ");
                    newRestaurant.sState = Console.ReadLine();
                    return "AddRestaurant";
                case "5":
                    Console.Write("Enter Country: ");
                    newRestaurant.sContry = Console.ReadLine();
                    return "AddRestaurant";
                case "6":
                    Console.Write("Enter Name: ");
                    newRestaurant.sName = Console.ReadLine();
                    return "AddRestaurant";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "AddRestaurant";
            }
        }
    }
}
