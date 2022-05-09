using BL;
using UI;

internal class LoginUser : IMenus
{
    private static string name = "";
    private static string pass = "";
    readonly IUserLogic logic;
    public LoginUser(IUserLogic logic)
    { this.logic = logic; }
    public void DisplayOptions()
    {
        Console.WriteLine("----------- Login Menu -----------\n");
        Console.WriteLine($"   <3> User Name: {name}");
        Console.WriteLine("   <2> Password:");
        Console.WriteLine($"   <1> Login");
        Console.WriteLine("   <0> Go Back\n");
        Console.WriteLine("\n----------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        string sInput = Console.ReadLine();
        Console.Write("\n");
        DateTime localDate = DateTime.Now;

        switch (sInput)
        {
            case "0":
                Console.Clear();
                pass = "";
                name = "";
                return "StartMenu";
            case "1":
                //return "AdminMenu";
                return "UserMenu";
            case "2":
                Console.Write("Enter Password: ");
                pass = Console.ReadLine();
                Console.Clear();
                return "LoginUser";
            case "3":
                Console.Write("Enter UserName: ");
                name = Console.ReadLine();
                Console.Clear();
                return "LoginUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "LoginUser";
        }
    }
}