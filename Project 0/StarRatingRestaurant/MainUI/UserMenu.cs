using MainUI;

internal class UserMenu : IMenu
{
    public void Display()
    {
        Console.WriteLine("----------- User Menu -----------\n");
        Console.WriteLine("   <1> Find and Rate a Restaurant");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine($"ID: ************".PadLeft(34));
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
                return "FindRateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
}