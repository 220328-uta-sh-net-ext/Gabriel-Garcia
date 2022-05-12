using UI;

internal class RateRestaurant : IMenus
{
    public static string menu { get; set; }
    public static string user { get; set; }

    //readonly IUserLogic logic;
    //readonly IReviewLogic logicRev;
    //public FindUser(IUserLogic logic, IReviewLogic logicRev)
    //{ this.logic = logic; this.logicRev = logicRev; }
    public void DisplayOptions()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine("   <4> Set Restaurant to Review");
        Console.WriteLine("   <3> Filter Restaurant by Name");
        Console.WriteLine("   <2> Filter Restaurant by City");
        Console.WriteLine($"   <1> Rate Restaurant: ");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine($"                              User:{user}");
        Console.WriteLine("\n------------------------------------\n");
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
                GC.Collect();
                return menu;
            case "1":
                return "RateRestaurant";
            case "2":
                Console.Clear();
                return "RateRestaurant";
            case "3":
                return "RateRestaurant";
            case "4":
                return "RateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "CreateUser";
        }
    }
}