using MainUI;
using MainBL;
internal class FindUser : IMenu
{
    //private string sUser="";
    readonly IUserLogic logic;
    public FindUser(IUserLogic logic)
    { this.logic = logic; }
    public void Display()
    {
        Console.WriteLine("---- Find Users (Admin only) ----\n");
        Console.WriteLine("   <4> Find User By First Name ");
        Console.WriteLine("   <3> Find User By Last Name ");
        Console.WriteLine("   <2> Find User By User Name ");
        Console.WriteLine("   <1> Display All User ");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("----------------------------------\n");
    }

    public string UserChoice()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");

        Console.Write("\n");
        Log.Information("Admin searched for users");
        switch (sInput)
        {
            case "0":
                Console.Clear();
                return "AdminMenu";
            case "1":
                Console.Clear();
                Find("","");
                return "FindUser";
            case "2":
                Console.Write("Enter User Name: ");
                if (Console.ReadLine() is not string u)
                    throw new InvalidDataException("?");
                Console.Clear();
                //Console.WriteLine(u);
                Find(u,"uname");
                return "FindUser";
            case "3":
                Console.Write("Enter User Name: ");
                if (Console.ReadLine() is not string l)
                    throw new InvalidDataException("?");
                Console.Clear();
                Find(l,"lname");
                return "FindUser";
            case "4":
                Console.Write("Enter User Name: ");
                if (Console.ReadLine() is not string f)
                    throw new InvalidDataException("?");
                Console.Clear();
                Find(f,"fname");
                return "FindUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindUser";
        }
    }
    private void Find(string name, string n)
    {
        Console.WriteLine();
        List<MainML.User>? results = logic.DisplayUser();
        results = logic.SearchUser(name, n);
        if (results.Count > 0)
        {
            foreach (MainML.User? r in results)
            {
                if(r.UserName != "Admin")
                    Console.WriteLine(r.ToString());
            }
        }
        else
            Console.WriteLine("User Not Found");

        if (name == "" && n != "")
        { Console.WriteLine("\nYou Input '' so I printed all of them!"); }
    }
}