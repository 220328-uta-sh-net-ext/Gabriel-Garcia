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
        Console.WriteLine("   <2> Password: ".PadRight((17 + pass.Length), '*'));
        Console.WriteLine($"   <1> Login");
        Console.WriteLine("   <0> Go Back\n");
        Console.WriteLine("\n----------------------------------\n");
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
                pass = "";
                name = "";
                return "StartMenu";
            case "1":
                UserMenu.username = name;
                string logingin = logic.LogingIn(name, pass);
                pass = "";
                name = "";
                Console.Clear();
                return logingin;
            case "2":
                pass = "";
                Console.Write("Enter Password: ");
                pass += Console.ReadLine();
                Console.Clear();
                return "LoginUser";
            case "3":
                name = "";
                Console.Write("Enter UserName: ");
                name += Console.ReadLine();
                Console.Clear();
                return "LoginUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "LoginUser";
        }
    }
}