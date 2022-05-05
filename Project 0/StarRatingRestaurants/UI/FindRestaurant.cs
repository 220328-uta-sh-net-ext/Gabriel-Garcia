using UI;
using BL;
using Models;


internal class FindRestaurant : IMenus
{
    static readonly Restaurant Rest = new();
    readonly IRestaurantLogic logic;
    public FindRestaurant(IRestaurantLogic logic)
    { this.logic = logic; }
    public void DisplayOptions()
    {
        Console.WriteLine("-------- Find And Review Restaurant ---------\n");

        Console.WriteLine("   <6> Find Restaurant By Name ");
        Console.WriteLine("   <5> Find Restaurant By Country ");
        Console.WriteLine("   <4> Find Restaurant By State ");
        Console.WriteLine("   <3> Find Restaurant By Zipcode ");
        Console.WriteLine(" * <2> Find Restaurant By ID ");
        Console.WriteLine("   <1> Display All User ");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine($"User: ****** ".PadLeft(34));
        Console.WriteLine("\n-------------------------------------------\n");
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
                logic.AddRestaurant(Rest);
                Rest.Name = "New Rest Test";
                Rest.Id = "Id setter";
                Rest.Country = "USA";
                Rest.State = "States";
                Rest.City = "Citys";
                Rest.Zipcode = "Code";
                logic.AddRestaurant(Rest);

                Console.Clear();
                return "FindRateRestaurant";
            case "2":
                Console.Clear();
                return "FindRateRestaurant";
            case "3":
                Console.Clear();
                return "FindRateRestaurant";
            case "4":
                Console.Clear();
                return "FindRateRestaurant";
            case "5":
                Console.Clear();
                return "FindRateRestaurant";
            case "6":
                Console.Clear();
                return "FindRateRestaurant";
            case "7":
                Console.Clear();
                return "FindRateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindRateRestaurant";
        }
    }
}