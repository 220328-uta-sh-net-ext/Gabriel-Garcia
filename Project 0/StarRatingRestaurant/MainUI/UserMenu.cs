using MainUI;

internal class UserMenu : IMenu
{
    private static string name;
    public void Display()
    {
        Console.WriteLine("----------- User Menu -----------\n");
        Console.WriteLine("   <1> Find and Rate a Restaurant");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine($"ID: {name}".PadLeft(34));
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