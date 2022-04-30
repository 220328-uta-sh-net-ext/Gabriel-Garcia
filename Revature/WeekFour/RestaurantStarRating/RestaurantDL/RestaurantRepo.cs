using RestaurantML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RestaurantDL
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private string sFilePath = "../../../../RestaurantDL/Database/";
        private string sJsonString;
        public Restaurant AddRestaurant(Restaurant rest)//serialization
        {
            var vRestaurants = GetAllRestaurants();
            vRestaurants.Add(rest);
            var vRestaurantString = JsonSerializer.Serialize<List<Restaurant>>(vRestaurants,new JsonSerializerOptions {WriteIndented=true});
            try 
            { 
                File.WriteAllText(sFilePath+"Restaurant.json",vRestaurantString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name" + ex.Message);
            }
            return rest;
        }

        public Restaurant AddReview(Restaurant rest)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetAllRestaurants()//desrialization
        {
            try 
            {
                sJsonString = File.ReadAllText(sFilePath+"Restaurant.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name" + ex.Message);
            }
            if (!string.IsNullOrEmpty(sJsonString))
                return JsonSerializer.Deserialize<List<Restaurant>>(sJsonString);
            else
                return null;
        }
        public List<Restaurant> SetReview()//desrialization
        {
            try
            {
                sJsonString = File.ReadAllText(sFilePath + "Restaurant.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name" + ex.Message);
            }
            var vRest = JsonSerializer.Deserialize<List<Restaurant>>(sJsonString);
            
            if (!string.IsNullOrEmpty(sJsonString))
                return JsonSerializer.Deserialize<List<Restaurant>>(sJsonString);
            else
                return null;
        }
    }
}