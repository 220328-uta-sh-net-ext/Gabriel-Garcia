using RestaurantBL;
using RestaurantUI;

internal class AddReview : IMenu
{
    IRestaurantLogic repo = new RestaurantLogic();
    private static string name = FindRestaurant.sInputName;
    private static string id = FindRestaurant.sInputID;
    private int sRate;

    public void Display()
    {
        Console.WriteLine("Rate a Restaurant ");
        Console.WriteLine("<1> Give a Rating:");
        Console.WriteLine("<0>Exit:");
    }

    public string UserChoice()
    {
        Console.WriteLine("+------------------+");
        repo.PrintRateRestaurant(name, id);
        Console.Write("Enter: ");
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "0":
                return "Admin Menu";
            case "1":
                Console.WriteLine($"<1> <2> <3> <4> <5>: ");
                Console.Write($"\nRate the Restaurant: ");
                try
                {
                    sRate = Convert.ToInt32(Console.ReadLine());
                    if (sRate > 0 && sRate <= 5)
                    {
                        //do this
                        repo.RateRestaurant(name, id);
                        Console.WriteLine("A valid input: " + sRate);
                    }
                    else
                        Console.WriteLine("Not a valid input: "+sRate);
                }
                catch(System.FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
                Console.ReadLine();
                Console.Clear();
                return "AddReview";
            
            default:
                Console.WriteLine("Please enter a valid response");
                Console.WriteLine("Please press <enter> to continue");
                Console.ReadLine();
                return "AddReview";
        }
    }
}