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
        public void Display()
        {
            Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine($"<3> Zipcode: {AddRestaurant.newLocation.Zipcode}");
            Console.WriteLine($"<2> State: {AddRestaurant.newLocation.State}");
            Console.WriteLine($"<1> Country: {AddRestaurant.newLocation.Contry}");
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
                    AddRestaurant.newLocation.Contry = Console.ReadLine();
                    Console.Clear();
                    return "Add Location";
                case "2":
                    Console.Write("Enter State: ");
                    AddRestaurant.newLocation.State = Console.ReadLine();
                    Console.Clear();
                    return "Add Location";
                case "3":
                    Console.Write("Enter Zipcode: ");
                    AddRestaurant.newLocation.Zipcode= Console.ReadLine();
                    Console.Clear();
                    return "Add Location";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "Add Location";
            }
        }
    }
}
