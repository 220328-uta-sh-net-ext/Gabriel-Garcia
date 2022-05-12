using BL;
using UI;
using Models;

internal class UserMenu : IMenus
{
    static readonly User user = new();
    readonly IUserLogic logic;

    public UserMenu(IUserLogic logic)
    {
        this.logic = logic;
    }
    public static string username { get; set; }
    public void DisplayOptions()
    {
        Console.WriteLine("----------- User Menu -----------\n");
        Console.WriteLine("   <3> Delete Account");
        Console.WriteLine("   <2> Find a Restaurant");
        Console.WriteLine("   <1> Rate a Restaurant");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine($"User: {username}".PadLeft(34));
        Console.WriteLine("----------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        string sInput = Console.ReadLine();
        Console.Write("\n");

        switch (sInput)
        {
            case "0":
                Console.Clear();
                return "StartMenu";
            case "1":
                Console.Clear();
                return "FindRestaurant";
            case "2":
                Console.Clear();
                return "RateRestaurant";
            case "3":
                Console.Clear();
                return DeleteAccount();
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
    private string DeleteAccount()
    {
        string id = "";
        Console.Write("Would you like to Delete your Account:");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
        if (sInput == "Yes")
        {
            List<User> findid = logic.SearchUser("UserName", username);
            foreach (User item in findid)
            {
                id = item.ReviewerId;
            }
            Console.Write($"{id} {username}");
            logic.DeleteUser(username, id);
            return "StartMenu";
        }
        else return "UserMenu";
    }
}