using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserML;
using UserBL;

namespace RestaurantUI
{
    internal class AddUser : IMenu
    {
        private static User newUser = new User();
        private IUserLogic _repo = new UserLogic();
        public void Display()
        {
            Console.WriteLine("Adding a New Account\n");

            Console.WriteLine("<5> First Name: " + newUser.FirstName);
            Console.WriteLine("<4> Last Name: " + newUser.LastName);
            Console.WriteLine("<3> User Name: " + newUser.UserName);
            if (newUser.Password == "")
                Console.WriteLine("Press <2> Password:");
            else
                Console.WriteLine("Press <2> Password: ***");
            Console.WriteLine("<1> Create Account");
            Console.WriteLine("<0> Go Back");
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
                        _repo.AddUser(newUser);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Clear();
                    return "MainMenu";
                case "2":
                    Console.Write("Enter a Password: ");
                    newUser.Password = Console.ReadLine();
                    Console.Clear();
                    return "Create User";
                case "3":
                    Console.Write("Enter a Loggin Name: ");
                    newUser.UserName = Console.ReadLine();
                    Console.Clear();
                    return "Create User";
                case "4":
                    Console.Write("Enter Last Name: ");
                    newUser.LastName = Console.ReadLine();
                    Console.Clear();
                    return "Create User";
                case "5":
                    Console.Write("Enter First Name: ");
                    newUser.FirstName = Console.ReadLine();
                    Console.Clear();
                    return "Create User";
                default:
                    Console.Clear();
                    Console.WriteLine($"Your input '{sUserInput}' is invalid!");
                    return "Create User";
            }
        }
    }
}
