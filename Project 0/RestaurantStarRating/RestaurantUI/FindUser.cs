using UserBL;
using RestaurantUI;

internal class FindUser : IMenu
{
    IUserLogic repo = new UserLogic();
    private static string sInput = "";
    public void Display()
    {
        Console.WriteLine("Finding a User ");
        Console.WriteLine("<3>User ID:");
        Console.WriteLine("<2>User Name:"); 
        Console.WriteLine("<1>Display all User:");
        Console.WriteLine("<0>Exit:");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "0":
                return "Admin Menu";
            case "1":
                repo.SearchUser();
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            case "2":
                Console.Write("Please enter the Username: ");
                sInput = Console.ReadLine();
                repo.SearchUserName(sInput);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            case "3":
                Console.Write("Please enter the User ID: ");
                sInput = Console.ReadLine();
                repo.SearchUserID(sInput);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            default:
                Console.WriteLine("Please enter a valid response");
                Console.WriteLine("Please press <enter> to continue");
                Console.ReadLine();
                return "FindUser";
        }
    }
}