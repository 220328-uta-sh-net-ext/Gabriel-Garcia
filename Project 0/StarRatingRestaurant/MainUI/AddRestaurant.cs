using MainUI;

internal class AddRestaurant : IMenu
{
    //private static Restaurant newRestaurant = new Restaurant();
    //public static Location newLocation = new Location();
    //private IRestaurantLogic _repository = new RestaurantLogic();//up casting
    private static string name = "";
    private static string id = "";
    private static string contry = "";
    private static string state = "";
    private static string zip = "";
    private static string type = "";

    public void Display()
    {
        Console.WriteLine("-------- Adding Restaurant ---------\n");
        Console.WriteLine($"   <4> Restaurant's Name: {name}");
        Console.WriteLine($"   <3> Add Location: {contry} {state} {zip}");
        Console.WriteLine($"   <2> Type's: {type}");
        Console.WriteLine("   <1> Add Restaurant");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n----------------------------------\n");
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
                //try
                //{
                //    if (!(newLocation.Contry != "" || newLocation.State != "" || newLocation.Zipcode != ""))
                //    {
                //        newRestaurant.Locations.Clear();
                //        newRestaurant.Locations.Add(newLocation);
                //        _repository.AddRestaurant(newRestaurant);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //Console.Clear();
                return "AdminMenu";
            case "2":
                Console.Write("Enter type: ");
                //newRestaurant.Type = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            case "3":
                Console.Write("Enter Contry: ");
                contry = Console.ReadLine();
                Console.Write("Enter State: ");
                state = Console.ReadLine();
                Console.Write("Enter Zipcode: ");
                zip = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            case "4":
                Console.Write("Enter Name: ");
                //newRestaurant.Name = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddRestaurant";
        }
    }
}