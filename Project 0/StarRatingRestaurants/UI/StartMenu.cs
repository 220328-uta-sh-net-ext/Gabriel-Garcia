using UI;

internal class StartMenu : IMenus
{
    public void DisplayOptions()
    {
        Console.WriteLine("-- Welcome to Restaurant Review --\n");
        Console.WriteLine("   <3> Fand a Restaurant");
        Console.WriteLine("   <2> Create User");
        Console.WriteLine("   <1> Login User");
        Console.WriteLine("   <0> Exit");
        Console.WriteLine("\n----------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");

        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");

        switch (sInput)
        {
            case "0":
                Console.Clear();
                return "Exit";
            case "1":
                Console.Clear();
                return "LoginUser";
            case "2":
                Console.Clear();
                return "CreateUser";
            case "3":
                Console.Clear();
                return "FindRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "StartMenu";
        }
    }
}