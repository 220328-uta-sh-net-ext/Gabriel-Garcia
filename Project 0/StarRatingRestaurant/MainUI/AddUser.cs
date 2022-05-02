using MainUI;
using MainBL;
using MainML;

internal class AddUser : IMenu
{    
    static readonly User nUser = new();
    readonly IUserLogic logic;

    public AddUser(IUserLogic logic)
    {
        this.logic = logic;
    }
    public void Display()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine($"   <5> First Name: {nUser.FName}");
        Console.WriteLine($"   <4> Last Name: {nUser.LName}");
        Console.WriteLine($"   <3> User Name: {nUser.UserName}");
        if (nUser.Password == "") Console.WriteLine("   <2> Password:");
        else Console.Write("   <2> Password: ".PadRight((17+nUser.Password.Length),'*')+"\n");
        Console.WriteLine("   <1> Create Account");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n------------------------------------\n");
    }

    public string UserChoice()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
        Console.Write("\n");

        switch (sInput)
        {
            case "0":
                Console.Clear();
                setInputToB();
                GC.Collect();
                return "StartMenu";
            case "1":
                if (getMiss(nUser.FName, nUser.LName, nUser.UserName, nUser.Password))
                {
                    List<MainML.User>? results = logic.DisplayUser();
                    results = logic.SearchUser(nUser.UserName, "uname");
                    if (results.Count > 0)
                    {
                        foreach (MainML.User? r in results)
                        {
                            if (r.UserName == nUser.UserName)
                            {
                                Console.WriteLine("User Name already exists ");
                                return "AddUser";
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            logic.AddUser(nUser);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    printMiss(nUser.FName, nUser.LName, nUser.UserName, nUser.Password);
                    return "AddUser";
                }
                Console.WriteLine("Your Account was Made.\n");
                Console.Write("\n\tPress <enter> to continue\n   >");
                Console.ReadLine();
                setInputToB();
                Console.Clear();
                return "StartMenu";
            case "2":
                Console.Write("Enter a Password: ");
                nUser.Password = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "3":
                Console.Write("Enter a User Name: ");
                nUser.UserName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "4":
                Console.Write("Enter a Last  Name: ");
                nUser.LName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "5":
                Console.Write("Enter a Fist Name: ");
                nUser.FName = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddUser";
        }
        
    }
    private void setInputToB()
    {
        nUser.FName = ""; 
        nUser.LName = "";
        nUser.UserName = ""; 
        nUser.Password = "";
    }
    private bool getMiss(string f, string l, string u, string p)
    {
        if (f == "")
            return false;
        else if (l == "")
            return false;
        else if (u == "")
            return false;
        else if (p == "")
            return false;
        else
        return true;

    }
    private void printMiss(string f, string l, string u, string p)
    {
        string miss = "";
        if (f == "")
            miss += " (Fisrt Name) ";
        if (l == "")
            miss += " (Last Name) ";
        if (u == "")
            miss += " (Last Name) ";
        if (p == "")
            miss += " (Passsword Name) ";

        Console.WriteLine($"Missing {miss}");
    }
}