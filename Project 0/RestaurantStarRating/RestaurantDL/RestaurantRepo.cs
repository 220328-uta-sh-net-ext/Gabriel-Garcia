using RestaurantML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RestaurantDL
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private string sFilePath = @"..\..\..\..\RestaurantDL\Database\";
        private string sJSONstring = "";
        public Restaurant AddRestaurant(Restaurant rest)
        {
            throw new NotImplementedException();
        }

        public void GetAllRestaurants()
        {
            // try 
            //  {
            //File.Create(sFilePath + "k2Rest.json");
                sJSONstring = File.ReadAllText(sFilePath+"Restaurant.json");
                Console.WriteLine(sJSONstring);
          //  }
           // catch (Exception ex)
           // {
            //    Console.WriteLine("Please check the path, " + ex.Message);
           // }
        }

        List<Restaurant> IRestaurantRepo.GetAllRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}