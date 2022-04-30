using MainUI;

internal class FindUser : IMenu
{
    //IUserLogic repo = new UserLogic();
    //private static string sInput = "";
    public void Display()
    {
        Console.WriteLine("----------- Find Users -----------\n");
        Console.WriteLine("   <3> User ID: ");
        Console.WriteLine("   <2> User Name: ");
        Console.WriteLine("   <1> Display All User ");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("----------------------------------\n");
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
                return "AdminMenu";
            case "1":
                //repo.SearchUser();
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            case "2":
                Console.Write("Enter User Name: ");
                //sInput = Console.ReadLine();
                //repo.SearchUserName(sInput);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            case "3":
                Console.Write("Enter User ID: ");
                //sInput = Console.ReadLine();
                //repo.SearchUserID(sInput);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindUser";
        }
    }
}