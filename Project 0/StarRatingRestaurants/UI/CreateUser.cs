using BL;
using Models;
using UI;

internal class CreateUser : IMenus
{
    readonly IUserLogic logic;
    static readonly User user = new();

    public CreateUser(IUserLogic logic)
    {
        this.logic = logic;
    }
    public void DisplayOptions()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine($"   <6> First Name:");
        Console.WriteLine($"   <5> Last Name: ");
        Console.WriteLine($"   <4> Email: ");
        Console.WriteLine($"   <3> User Name: ");
        Console.WriteLine("   <2> Password:");
        Console.WriteLine("   <1> Create Account");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n------------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("404");
        Console.Write("\n");

        switch (sInput)
        {
            case "0":
                Console.Clear();
                GC.Collect();
                return "StartMenu";
            case "1":
                user.ReviewerId = "0123";
                logic.AddUser(user);
                Console.Clear();
                return "StartMenu";
            case "2":
                Console.Write("Enter a Password: ");
                user.Password = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "3":
                Console.Write("Enter a User Name: ");
                user.UserName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "4":
                Console.Write("Enter a Email: ");
                user.Email = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "5":
                Console.Write("Enter a Last Name: ");
                user.LastName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "6":
                Console.Write("Enter a First Name: ");
                user.FirstName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddUser";
        }

    }
}