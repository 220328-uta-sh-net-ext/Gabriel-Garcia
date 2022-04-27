using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantML;
using RestaurantBL;

namespace RestaurantUI
{
    internal class AddLocationForRestaurant : IMenu
    {
        public static Location newLocation = new Location();
        private IRestaurantLogic _reposityory = new RestaurantLogic();//up casting

        public void Display()
        {
            Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine("<3> Zipcode: ");
            Console.WriteLine("<2> State: ");
            Console.WriteLine("<1> Country");
            Console.WriteLine("<0> Go Back");
            Console.WriteLine();
        }

        public string UserChoice()
        {
            string sUserInput = Console.ReadLine();
            switch (sUserInput)
            {
                case "0":
                    Console.Clear();
                    return "Add Restaurant";
                case "1":
                    Console.Write("Enter Country: ");
                    newLocation.sContry = Console.ReadLine();
                    return "Add Location";
                case "2":
                    Console.Write("Enter State: ");
                    newLocation.sState = Console.ReadLine();
                    return "Add Location";
                case "3":
                    Console.Write("Enter Zipcode: ");
                    newLocation.sZipcode= Console.ReadLine();
                    return "Add Location";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "Add Location";
            }
        }
    }
}
