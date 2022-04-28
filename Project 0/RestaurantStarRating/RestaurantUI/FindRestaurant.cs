using RestaurantBL;
using RestaurantUI;

internal class FindRestaurant : IMenu
{
    IRestaurantLogic repo = new RestaurantLogic();
    public static string sInputID = "";
    private static string sInputType = "";
    private static string sInputContry = "";
    private static string sInputState = "";
    private static string sInputZip = "";
    public static string sInputName = "";
    public void Display()
    {
        Console.WriteLine("Finding and Rate a Restaurant ");
        Console.WriteLine($"<8> Enter Type: {sInputType}");
        Console.WriteLine($"<7> Enter Contry: {sInputContry}");
        Console.WriteLine($"<6> Enter State: {sInputState}");
        Console.WriteLine($"<5> Enter Zipcode: {sInputZip}");
        Console.WriteLine($"<4>* Enter ID {sInputID}");
        Console.WriteLine($"<3>* Enter Name:: {sInputName}");
        Console.WriteLine($"<2> Rate a Restaurant: Compleat all '*' ");
        Console.WriteLine("<1> Display all Restaurant:");
        Console.WriteLine("<0>Exit:");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "0":
                return "Admin Menu";
            case "1":
                repo.SearchRestaurant();
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindRestaurant";
            case "2":
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                Console.Clear();
                return "FindRestaurant";
            case "3":
                Console.Write("Please enter the Name: ");
                sInputName = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            case "4":
                Console.Write("Please enter the ID: ");
                sInputID = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            case "5":
                Console.Write("Please enter the Zipcode: ");
                sInputZip = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            case "6":
                Console.Write("Please enter the State ");
                sInputState = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            case "7":
                Console.Write("Please enter the Contry: ");
                sInputContry = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            case "8":
                Console.Write("Enter Type of Restaurant: ");
                sInputType = Console.ReadLine();
                Console.Clear();
                repo.SearchRestaurant(sInputType, sInputContry, sInputState, sInputZip, sInputName, sInputID);
                Console.WriteLine("Press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
            default:
                Console.WriteLine("Please enter a valid response");
                Console.WriteLine("Please press <enter> to continue");
                Console.ReadLine();
                return "FindRestaurant";
        }
    }
}