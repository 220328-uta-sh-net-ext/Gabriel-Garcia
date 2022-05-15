using UI;

internal class AdminMenu : IMenus
{
    public void DisplayOptions()
    {
        Console.WriteLine("----------- Admin Menu -----------\n");
        Console.WriteLine("   <5> Delete Restaurant");
        Console.WriteLine("   <4> Add a Restaurant");
        Console.WriteLine("   <3> Rate a Restaurant");
        Console.WriteLine("   <2> Find a Restaurant");
        Console.WriteLine("   <1> Find a User");
        Console.WriteLine("   <0> Logout");
        Console.WriteLine("----------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
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
                FindRestaurant.menu = "AdminMenu";
                FindRestaurant.user = "Admin";
                return "FindRestaurant";
            case "3":
                Console.Clear();
                RateRestaurant.menu = "AdminMenu";
                RateRestaurant.user = "Admin";
                return "RateRestaurant";
            case "4":
                Console.Clear();
                return "AddRestaurant";
            case "5":
                Console.Clear();
                return "DeleteRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
}