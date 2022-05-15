using BL;
using Models;
using UI;

internal class RateRestaurant : IMenus
{
    public static string menu { get; set; }
    public static string user { get; set; }
    private static string RestID = "";

    static readonly Reviews rev = new();
    readonly IUserLogic Userlogic;
    readonly IReviewLogic Revlogic;
    readonly IRestaurantLogic RestLogic;
    public RateRestaurant(IUserLogic Userlogic, IReviewLogic Revlogic,IRestaurantLogic RestLogic)
    { this.Userlogic = Userlogic; this.Revlogic = Revlogic; this.RestLogic = RestLogic; }
    public void DisplayOptions()
    {
        Console.WriteLine("---------- Adding Account ----------\n");
        Console.WriteLine("   <3> Filter Restaurant by Name");
        Console.WriteLine("   <2> Filter Restaurant by Id");
        Console.WriteLine($"   <1> Rate Restaurant: {RestID}");
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
                Console.Clear();
                if (RestID != "")
                    return SetUpReview(GetUserReviewID("UserName", user), RestID);
                else { Console.WriteLine("Please set a Restaurant"); }
                return "RateRestaurant";
            case "2":
                Console.Write("Enter the Restaurant's id: ");
                if (Console.ReadLine() is not string id)
                    throw new InvalidDataException("");
                FindARestaruant("Id", id);
                Console.Clear();
                return "RateRestaurant";
            case "3":
                Console.Write("Enter the Restaurant's name: ");
                if (Console.ReadLine() is not string name)
                    throw new InvalidDataException("");
                FindARestaruant("Name", name);
                return "RateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "CreateUser";
        }
    }
    private void FindARestaruant(string whereIt,string equalsTo)
    {
        List<Restaurant>? restaurant = RestLogic.SearchRestaurant(whereIt, equalsTo);
        List<Restaurant>? restLocation;
        if (restaurant.Count > 0)
        {
            foreach(Restaurant r in restaurant)
            {
                restLocation = RestLogic.SearchRestLocation("Id", r.Id);
                foreach(Restaurant l in restLocation)
                {
                    Console.Clear();
                    Console.WriteLine($"Restaurant:\n");
                    Console.WriteLine($"Name: {r.Name}\tID: {r.Id}\n   Location: {l.Country} {l.State} {l.City} {l.Zipcode}");
                    Console.Write($"\nWill You You Be Reting this Restaurant <Yes> <Any Key for No>: ");
                }
                string n = "" + Console.ReadLine();
                if (n == "Yes")
                { RestID = r.Id; break; }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");
    }
    private string GetUserReviewID(string whereIt, string equalsTo)
    {
        List<User>? users = Userlogic.SearchUser(whereIt, equalsTo);
        if (users.Count > 0)
        {
            foreach (User u in users)
            {
                return u.ReviewerId;
            }
        }
        return "Error! UserId Not Found";
    }
    private string SetUpReview(string userID, string RestID)
    {
        string sReview = "";
        int iNumInput = 0;
        bool whilethis = false;
            whilethis = CheckIfUserHasAReview();
        if (whilethis == false)
        {
            return "RateRestaurant";
        }
        while(whilethis)
        {
            Console.WriteLine("<1> <2> <3> <4> <5>");
            Console.Write("Enter restaurnat's rating: ");
            iNumInput = Convert.ToInt32( Console.ReadLine() );
            if (iNumInput > 0 && iNumInput < 6)
                whilethis = false;
            else
            {
                Console.Clear();
                Console.WriteLine("Your Input was an invalid value, Please enter a valid value! ");
                Console.WriteLine("Would you like to contiue <Yes> or <Input Any Thing>:");
                if (Console.ReadLine() != "Yes")
                {
                    return "RateRestaurant";
                }
            }
        }
        Console.WriteLine($"\n<Yes> or <Any Key for No>: ");
        Console.Write("Would you like to add a Review? ");
        if(Console.ReadLine() == "Yes")
        {
            Console.Write("Your Review: > ");
            sReview += Console.ReadLine();
        }

        Console.WriteLine("Setting up your Review");
        rev.Id = RestID;
        rev.ReviewerId = userID;
        rev.Rate = iNumInput;
        rev.Review = sReview;

        Userlogic.AddReviews(rev);
        Console.WriteLine("Review Done.");

        return "RateRestaurant";
    }
    private bool CheckIfUserHasAReview()
    {
        List<Reviews>? review = Revlogic.DisplayReview("ReviewerID", GetUserReviewID("UserName",user));
        if (review.Count > 0)
        {
            foreach(Reviews v in review)
            {
                if (v.Id == RestID && v.ReviewerId == GetUserReviewID("UserName", user))
                {
                    Console.Clear();
                    Console.WriteLine($"We have found a Review for this Restaurant, Would you like to change it '{v.Rate}'?\n");
                    Console.Write($"\n<Yes> or <Any Key for No>: ");
                    string n = "" + Console.ReadLine();
                    if (n == "Yes")
                    {
                        Revlogic.DeleteReview("Id",RestID , "ReviewerID", GetUserReviewID("UserName", user));
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
        return true;
    }
}