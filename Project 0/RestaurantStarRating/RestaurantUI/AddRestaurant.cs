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
        public static Location newLocation = new Location();
        private IRestaurantLogic _repository = new RestaurantLogic();//up casting

        public void Display()
        {
            Console.WriteLine("Adding a New Restaurant\n");

            Console.WriteLine($"<4> Restaurant's Name: {newRestaurant.Name}");
            Console.WriteLine($"<3> Add Location: {newLocation.Contry} {newLocation.State} {newLocation.Zipcode}");
            Console.WriteLine($"<2> Type's: {newRestaurant.Type}");
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
                    return "Admin Menu";
                case "1":
                    try 
                    {
                        if (!(newLocation.Contry != "" || newLocation.State != "" || newLocation.Zipcode != ""))
                        {
                            newRestaurant.Locations.Clear();
                            newRestaurant.Locations.Add(newLocation);
                            _repository.AddRestaurant(newRestaurant);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Clear();
                    return "Admin Menu";
                case "2":
                    Console.Write("Enter type: ");
                    newRestaurant.Type = Console.ReadLine();
                    Console.Clear();
                    return "Add Restaurant";
                case "3":
                    Console.Clear();
                    return "Add Location";
                case "4":
                    Console.Write("Enter Name: ");
                    newRestaurant.Name = Console.ReadLine();
                    Console.Clear();
                    return "Add Restaurant";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "Add Restaurant";
            }
        }
    }
}
