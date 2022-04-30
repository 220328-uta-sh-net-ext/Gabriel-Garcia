using MainUI;

internal class LoginUser : IMenu
{
    private static string name = "";
    private static string pass = "";
    //IUserLogic repo = new UserLogic();
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

        switch (sInput)
        {
            case "0":
                Console.Clear();
                pass = "";
                name = "";
                return "StartMenu";
            case "1":
                //var result = repo.SearchUser(uName, uPass);
                Console.Clear();
                //if (result == "Admin")
                //    return "Admin Menu";
                //else if (result == "User")
                //    return "User Menu";
                //else
                //    Console.WriteLine("UserName or Password Invalid!");
                return "LoginUser";
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