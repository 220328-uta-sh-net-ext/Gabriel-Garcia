using BL;
using Models;
using UI;

internal class CreateUser : IMenus
{
    readonly IUserLogic logic;
    static readonly User user = new();
    DateTime localDate = DateTime.Now;

    public CreateUser(IUserLogic logic)
    {
        this.logic = logic;
    }
    public void DisplayOptions()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine($"   <6> First Name: {user.FirstName}");
        Console.WriteLine($"   <5> Last Name: {user.LastName}");
        Console.WriteLine($"   <4> Email: {user.Email}");
        Console.WriteLine($"   <3> User Name: {user.UserName}");
        Console.WriteLine("   <2> Password: ".PadRight((17+user.Password.Length),'*'));
        Console.WriteLine("   <1> Create Account");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n------------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
        Console.Write("\n");

        switch (sInput)
        {
            case "0":
                Console.Clear();
                GC.Collect();
                return "StartMenu";
            case "1":

                Console.WriteLine($"{CheckIfUserExist(user.UserName)}");
                if (CheckIfUserExist(user.UserName))
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry! The username: '{user.UserName}' is taken. ");
                }
                else if (user.UserName == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry! You need to input a user name. ");
                }
                else
                {
                    Console.Clear();
                    user.ReviewerId = MakeUserID();
                    logic.AddUser(user);
                    Console.Write("\nYour Account Was Made.\n\n <Enter> To Continue: ");
                    Console.ReadLine();
                    Console.Clear();
                    return "StartMenu";
                }
                return "CreateUser";
            case "2":
                Console.Write("Enter a Password: ");
                user.Password = Console.ReadLine();
                Console.Clear();
                return "CreateUser";
            case "3":
                Console.Write("Enter a User Name: ");
                user.UserName = Console.ReadLine(); 
                if (CheckIfUserExist(user.UserName))
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry! The username: '{user.UserName}' is taken. ");
                }else
                    Console.Clear();
                return "CreateUser";
            case "4":
                Console.Write("Enter a Email: ");
                user.Email = Console.ReadLine();
                Console.Clear();
                return "CreateUser";
            case "5":
                Console.Write("Enter a Last Name: ");
                user.LastName = Console.ReadLine();
                Console.Clear();
                return "CreateUser";
            case "6":
                Console.Write("Enter a First Name: ");
                user.FirstName = Console.ReadLine();
                Console.Clear();
                return "CreateUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "CreateUser";
        }        
    }
    private string MakeUserID() 
    {
        int iCount = 0;
        List<User>? user = logic.DisplayAllUser();
        if (user.Count > 0)
        {
            foreach (User u in user)
            {
                iCount++;
            }
        }
        else
            Console.WriteLine("User Not Found");

        return localDate.Year.ToString() + localDate.Day.ToString() + localDate.Month.ToString() + localDate.Hour.ToString() + iCount;

    }
    private bool CheckIfUserExist(string equalsTo)
    {
        List<User>? user = logic.SearchUser("UserName", equalsTo);
        if (user.Count > 0)
        {
            return true;
        }else
        return false;
    }
}