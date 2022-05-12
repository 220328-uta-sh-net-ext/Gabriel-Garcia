using UI;

internal class AdminMenu : IMenus
{
    public void DisplayOptions()
    {
        Console.WriteLine("----------- Admin Menu -----------\n");
        Console.WriteLine("   <5> Delete Restaurant");
        Console.WriteLine("   <4> Add a Restaurant");
        Console.WriteLine("   <3> Review Restaurant");
        Console.WriteLine("   <2> Find Restaurant");
        Console.WriteLine("   <1> Find a User");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine($"User: ".PadLeft(34));
        Console.WriteLine("----------------------------------\n");
    }

    public string GetSendOptions()
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
                return "FindRestaurant";
            case "3":
                Console.Clear();
                return "RateRestaurant";
            case "4":
                Console.Clear();
                return "AddRestaurant";
            case "5":
                Console.Clear();
                return "DeleteRestaruant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
}