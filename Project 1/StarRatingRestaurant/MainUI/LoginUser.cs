using MainUI;
using MainBL;

internal class LoginUser : IMenu
{
    private static string name = "";
    private static string pass = "";
    readonly IUserLogic logic;
    public LoginUser(IUserLogic logic)
    { this.logic = logic; }
    public void Display()
    {
        Console.WriteLine("----------- Login Menu -----------\n");
        Console.WriteLine($"   <3> User Name: {name}");
        if (pass == "") Console.WriteLine("   <2> Password:");
        else { Console.Write("   <2> Password: ".PadRight((17+pass.Length),'*')+"\n"); }
        Console.WriteLine($"   <1> Login");
        Console.WriteLine("   <0> Go Back\n");
        Console.WriteLine("\n----------------------------------\n");
    }

    public string UserChoice()
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
                var result = logic.LogUser(name, pass);
                if (result == "UserMenu")
                {
                    pass = "";
                    UserMenu.setLog(name);
                    Log.Information($"User '{name}' loged in.");
                    name = "";
                    Console.Clear(); return "UserMenu"; 
                }
                else if (result == "AdminMenu")
                {
                    pass = "";
                    AdminMenu.setLog(name); 
                    Log.Information($" User '{name}' loged in.");
                    name = "";
                    Console.Clear(); return "AdminMenu"; 
                }
                else
                {
                    Console.WriteLine("User Name or Password Incorrect!");
                    Console.ReadLine();
                    Console.Clear();
                    return "LoginUser";
                }
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