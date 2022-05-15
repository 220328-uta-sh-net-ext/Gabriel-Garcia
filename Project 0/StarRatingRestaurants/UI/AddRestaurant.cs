using BL;
using UI;
using Models;

internal class AddRestaurant : IMenus
{
    readonly IRestaurantLogic logic;
    static readonly Restaurant rest = new();
    public AddRestaurant(IRestaurantLogic logic)
    {
        this.logic = logic;
    }
    public void DisplayOptions()
    {
        Console.WriteLine("-------- Adding Restaurant ---------\n");
        Console.WriteLine($"   <3> Restaurant's Name: ");
        Console.WriteLine($"   <2> Add Location:");
        Console.WriteLine("   <1> Add Restaurant");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n-----------------------------------\n");
    }

    public string GetSendOptions()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
        Console.Write("\n");
        DateTime localDate = DateTime.Now;
        switch (sInput)
        {
            case "0":
                GC.Collect();
                return "AdminMenu";
            case "1":
                rest.Id = localDate.Year.ToString()  + localDate.Month.ToString()  + localDate.Day.ToString() + numberOfRestaurant();
                logic.AddRestaurant(rest);
                Console.WriteLine("Restaurant Added to the Database.\n");
                Console.ReadLine();
                GC.Collect();
                Console.Clear();
                return "AddRestaurant";
            case "2":
                Console.WriteLine("If Not Applicable Input <none>");
                Console.Write("Enter Contry: ");
                rest.Country = Console.ReadLine();
                Console.Write("Enter State/Provinces: ");
                rest.State = Console.ReadLine();
                Console.Write("Enter City: ");
                rest.City = Console.ReadLine();
                Console.Write("Enter Zipcode: ");
                rest.Zipcode = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            case "3":
                Console.Write("Enter Name: ");
                rest.Name = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddRestaurant";
        }
    }
    private int numberOfRestaurant()
    {
        int iCount = 0;
        List<Restaurant>? rest = logic.DisplayAllRestaurants();
        if (rest.Count > 0)
        {
            foreach (Restaurant r in rest)
            {
                iCount++;
            }
        }
        Console.WriteLine(iCount);
        return 0;
    }
}