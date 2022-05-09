using UI;
using BL;
using Models;


internal class FindRestaurant : IMenus
{
    readonly IRestaurantLogic logic;
    readonly IReviewLogic logicRev;
    public FindRestaurant(IRestaurantLogic logic, IReviewLogic logicRev)
    { this.logic = logic; this.logicRev = logicRev; }
    public void DisplayOptions()
    {
        Console.WriteLine("-------- Find And Review Restaurant ---------\n");

        Console.WriteLine("   <7> Find Restaurant By Name ");
        Console.WriteLine("   <6> Find Restaurant By Country ");
        Console.WriteLine("   <5> Find Restaurant By State ");
        Console.WriteLine("   <4> Find Restaurant By City ");
        Console.WriteLine("   <3> Find Restaurant By Zipcode ");
        Console.WriteLine("   <2> Find Restaurant By ID ");
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
                DisplayAll();
                return "FindRateRestaurant";
            case "2":
                if (Console.ReadLine() is not string id)
                    throw new InvalidDataException("");
                Display("Name", id);
                return "FindRateRestaurant";
            case "3":
                if (Console.ReadLine() is not string zip)
                    throw new InvalidDataException("");
                Display("Name", zip);
                return "FindRateRestaurant";
            case "4":
                if (Console.ReadLine() is not string city)
                    throw new InvalidDataException("");
                Display("Name", city);
                return "FindRateRestaurant";
            case "5":
                if (Console.ReadLine() is not string state)
                    throw new InvalidDataException("");
                Display("Name", state);
                return "FindRateRestaurant";
            case "6":
                if (Console.ReadLine() is not string country)
                    throw new InvalidDataException("");
                Display("Country", country);
                return "FindRateRestaurant";
            case "7":
                if (Console.ReadLine() is not string name)
                    throw new InvalidDataException("");
                Display("Name", name);
                return "FindRateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindRateRestaurant";
        }
    }
    private void Display(string whereIt, string equalsTo)
    {
        List<Restaurant>? restaurant = logic.SearchRestaurant(whereIt, equalsTo);
        List<Restaurant>? restLocation;
        List<Reviews>? review;
        Console.WriteLine("\nRestaurant\n");
        if (restaurant.Count > 0)
        {
            foreach (Restaurant r in restaurant)
            {
                restLocation = logic.SearchRestLocation("Id", r.Id);
                review = logicRev.DisplayReview("Id", r.Id);
                foreach (Restaurant l in restLocation)
                {
                    Console.WriteLine($"Name: {r.Name}\tID: {r.Id}\n   Location: {l.Country} {l.State} {l.City} {l.Zipcode}");
                    foreach (Reviews re in review)
                    {
                        Console.WriteLine($"Rating: {re.Rate} {re.Review}");
                    }
                }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");

    }
    private void DisplayAll()
    {
        List<Restaurant>? restaurant = logic.DisplayAllRestaurants();
        List<Restaurant>? restLocation;
        List<Reviews>? review;
        Console.WriteLine("\nRestaurant\n");
        if (restaurant.Count > 0)
        {
            foreach (Restaurant r in restaurant)
            {
                restLocation = logic.SearchRestLocation("Id", r.Id);
                review = logicRev.DisplayReview("Id", r.Id);
                foreach (Restaurant l in restLocation)
                {
                    Console.WriteLine($"Name: {r.Name}\tID: {r.Id}\n   Location: {l.Country} {l.State} {l.City} {l.Zipcode}");
                    foreach (Reviews re in review)
                    {   if (re.Review == "")
                            Console.WriteLine("Not Yet Reated\n");
                        else
                            Console.WriteLine($"Rating: {re.Rate} {re.Review}\n");
                    }
                }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");

    }
}