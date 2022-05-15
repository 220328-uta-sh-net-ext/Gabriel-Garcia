using UI;
using BL;
using Models;


internal class FindRestaurant : IMenus
{
    readonly IRestaurantLogic logic;
    readonly IReviewLogic logicRev;
    public static string menu { get; set; }
    public static string user { get; set; }
    public FindRestaurant(IRestaurantLogic logic, IReviewLogic logicRev)
    { this.logic = logic; this.logicRev = logicRev; }
    public void DisplayOptions()
    {
        Console.WriteLine("---------- Look Up A Restaurant -----------\n");
        Console.WriteLine("   <7> Find Restaurant By Name ");
        Console.WriteLine("   <6> Find Restaurant By Country ");
        Console.WriteLine("   <5> Find Restaurant By State ");
        Console.WriteLine("   <4> Find Restaurant By City ");
        Console.WriteLine("   <3> Find Restaurant By Zipcode ");
        Console.WriteLine("   <2> Find Restaurant By ID ");
        Console.WriteLine("   <1> Display All User ");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine($"User: {user} ".PadLeft(34));
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
                return menu;
            case "1":
                Display(0, "", "");
                return "FindRestaurant";
            case "2":
                Console.Write($"Enter Restaurant ID: ");
                if (Console.ReadLine() is not string id)
                    throw new InvalidDataException("");
                Display(1, "Id", id);
                return "FindRestaurant";
            case "3":
                Console.Write($"Enter Restaurant Zipcode: ");
                if (Console.ReadLine() is not string zip)
                    throw new InvalidDataException("");
                Display(1, "Zipcode", zip);
                return "FindRestaurant";
            case "4":
                Console.Write($"Enter Restaurant City: ");
                if (Console.ReadLine() is not string city)
                    throw new InvalidDataException("");
                Display(1, "City", city);
                return "FindRestaurant";
            case "5":
                Console.Write($"Enter Restaurant State: ");
                if (Console.ReadLine() is not string state)
                    throw new InvalidDataException("");
                Display(1, "State", state);
                return "FindRestaurant";
            case "6":
                Console.Write($"Enter Restaurant Country: ");
                if (Console.ReadLine() is not string country)
                    throw new InvalidDataException("");
                Display(1,"Country", country);
                return "FindRestaurant";
            case "7":
                Console.Write($"Enter Restaurant Name: ");
                if (Console.ReadLine() is not string name)
                    throw new InvalidDataException("");
                Display(1,"Name", name);
                return "FindRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindRestaurant";
        }
    }
    private void Display(int i, string whereIt, string equalsTo)
    {
        float fCount = 0;
        float fTotal = 0;
        List<Restaurant>? restaurant = logic.DisplayAllRestaurants();
        if (i == 1)
            restaurant = logic.SearchRestaurant(whereIt, equalsTo);


        List<Restaurant>? restLocation;
        List<Reviews>? review;
        Console.WriteLine("\nRestaurant\n");
        if (restaurant.Count > 0)
        {
            foreach (Restaurant r in restaurant)
            {
                restLocation = logic.SearchRestLocation("Id", r.Id);
                Console.WriteLine(r.Id);
                review = logicRev.DisplayReview("Id", r.Id);
                foreach (Restaurant l in restLocation)
                {
                    Console.WriteLine($"Name: {r.Name}\tID: {r.Id}\n   Location: {l.Country} {l.State} {l.City} {l.Zipcode}");
                    if (review.Count == 0)
                        Console.WriteLine("Rating: Not Rated Yet!");
                    else
                    {
                        foreach (Reviews re in review)
                        {
                            fCount++;
                            fTotal += re.Rate;
                        }
                        fTotal = fTotal / (fCount * 5.0f);
                        Console.WriteLine($"Review {fCount} : {fTotal}");
                    }
                    Console.WriteLine();
                }
                fCount = 0;
                fTotal = 0;
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");
    }
}