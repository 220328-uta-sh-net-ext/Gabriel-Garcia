using UserML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UserDL
{
    public class UserRepo : IUserRepo
    {
        private string sFilePath = "../../../../UserDL/UserDatabase/";
        private string sJsonString;
        public User AddUser(User uUser)// Serialization
        {
            var vUser = GetAllUser();
            vUser.Add(uUser);
            var vUserString = JsonSerializer.Serialize<List<User>>(vUser, new JsonSerializerOptions { WriteIndented = true });
            try
            { 
                File.WriteAllText(sFilePath + "UserData.json", vUserString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return uUser;
        }

        public List<User> GetAllUser()// Deserialization
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