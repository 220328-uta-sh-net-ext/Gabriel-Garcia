using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantML;
using RestaurantBL;

namespace RestaurantUI
{
    internal class AddRestaurant : IMenu
    {
        private static Restaurant newRestaurant = new Restaurant();
        private IRestaurantLogic _reposityory = new RestaurantLogic();//up casting

        public void Display()
        {
            Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine("<4> Restaurant's Name: ");
            Console.WriteLine($"<3> Add Location: {AddLocationForRestaurant.newLocation.sContry} {AddLocationForRestaurant.newLocation.sState} {AddLocationForRestaurant.newLocation.sZipcode}");
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
                    Console.Clear();
                    return "MainMenu";
                case "1":
                    try 
                    { 
                        _reposityory.AddRestaurant(newRestaurant);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Clear();
                    return "MainMenu";
                case "2":
                    Console.Write("Enter type: ");
                    newRestaurant.sType = Console.ReadLine();
                    return "Add Restaurant";
                case "3":
                    Console.Clear();
                    return "Add Location";
                case "4":
                    Console.Write("Enter Name: ");
                    newRestaurant.sName = Console.ReadLine();
                    return "Add Restaurant";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "Add Restaurant";
            }
        }
    }
}
