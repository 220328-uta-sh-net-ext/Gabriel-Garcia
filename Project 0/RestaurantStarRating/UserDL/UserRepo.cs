using UserML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UserDL
{
    public class UserRepo : IUserRepo
    {
        private string sFilePath = @"..\..\..\..\RestaurantDL\Database\";
        private string sJsonString = "";
        public User AddUser(User uUser)
        {
            var vUser = GetAllRestaurants();
            vUser.Add(uUser);
            var vUserString = JsonSerializer.Serialize<List<User>>(vUser, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(sFilePath + "UserData.json", vUserString);
            return uUser;
        }

        public List<User> GetAllRestaurants()
        {
            try
            {
                sJsonString = File.ReadAllText(sFilePath + "UserData.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name" + ex.Message);
            }
            if (!string.IsNullOrEmpty(sJsonString))
                return JsonSerializer.Deserialize<List<User>>(sJsonString);
            else
                return null;
        }
    }
}