using MainUI;

internal class AdminMenu : IMenu
{
    private static string name;
    public void Display()
    {
        Console.WriteLine("----------- Admin Menu -----------\n");
        Console.WriteLine("   <3> Find and Rate a Restaurant");
        Console.WriteLine("   <2> Add a Restaurant");
        Console.WriteLine("   <1> Find a User");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine($"User: {name}".PadLeft(34));
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
                return "StartMenu";
            case "1":
                Console.Clear();
                return "FindUser";
            case "2":
                Console.Clear();
                return "AddRestaurant";
            case "3":
                Console.Clear();
                FindAndRateRestaurant.setLog(name);
                return "FindRateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
    public static void setLog(string n)
    {
        name = n;
    }

}