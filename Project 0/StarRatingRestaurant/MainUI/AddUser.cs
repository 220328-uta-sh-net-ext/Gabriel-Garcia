using MainUI;

internal class AddUser : IMenu
{
    //private static User newUser = new User();
    //private IUserLogic _repo = new UserLogic();
    private static string name = "";
    private static string password = "";
    public void Display()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine($"   <3> User Name: {name}");
        if (password == "") Console.WriteLine("   <2> Password:");
        else Console.Write("   <2> Password: ".PadRight((17+password.Length),'*')+"\n");
        Console.WriteLine("   <1> Create Account");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n----------------------------------\n");
    }

    public string UserChoice()
    {
        Console.Write("   > ");
        string sInput = Console.ReadLine();
        Console.Write("\n");
        DateTime localDate = DateTime.Now;
        string id = "";
        switch (sInput)
        {
            case "0":
                Console.Clear();
                return "StartMenu";
            case "1":
                if(name!= "")
                    id = name.Length + localDate.Year.ToString() + localDate.Day + name.First() + localDate.Hour + localDate.Minute;
                //try
                //{
                //   if (!_repo.SearchUser(newUser.UserName))
                //    {
                //        string n = newUser.UserName;
                //        n.ToArray();
                //        sID = localDate.Year.ToString() + n.Last() + localDate.Day + n.First() + localDate.Hour + localDate.Minute;
                //        newUser.ID = sID;
                //        _repo.AddUser(newUser);
                //    }
                //
                //    else
                //    {
                //        Console.WriteLine($"User name '{newUser.UserName}' is in use!");
                //        return "Create User";
                //    }
                //}
                //catch (Exception ex)
                //{
                //   Console.WriteLine(ex.Message);
                //}
                Console.WriteLine($"Your ID is > {id}".PadLeft(40));
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "StartMenu";
            case "2":
                Console.Write("Enter a Password: ");
                password = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            case "3":
                Console.Write("Enter a Loggin Name: ");
                name = Console.ReadLine();
                Console.Clear();
                return "AddUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddUser";
        }
    }
}