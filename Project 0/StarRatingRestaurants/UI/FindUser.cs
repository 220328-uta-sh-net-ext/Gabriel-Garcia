using BL;
using UI;
using Models;

internal class FindUser : IMenus
{
    readonly IUserLogic logic;
    readonly IReviewLogic logicRev;
    public FindUser(IUserLogic logic, IReviewLogic logicRev)
    { this.logic = logic; this.logicRev = logicRev; }
    public void DisplayOptions()
    {
        Console.WriteLine("---- Find Users (Admin only) ----\n");
        Console.WriteLine("   <5> Find User By First Name ");
        Console.WriteLine("   <4> Find User By Last Name ");
        Console.WriteLine("   <3> Find User By User Name ");
        Console.WriteLine("   <2> Find User By User ID ");
        Console.WriteLine("   <1> Display All User ");
        Console.WriteLine("   <0> Go Back");
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
                Display(0, "", "");
                return "FindUser";
            case "2":
                if (Console.ReadLine() is not string id)
                    throw new InvalidDataException("");
                Display(1, "ReviewerId", id);
                return "FindUser";
            case "3":
                if (Console.ReadLine() is not string uname)
                    throw new InvalidDataException("");
                Display(1, "UserName", uname);
                return "FindUser";
            case "4":
                if (Console.ReadLine() is not string lname)
                    throw new InvalidDataException("");
                Display(1, "LastName", lname);
                return "FindUser";
            case "5":
                if (Console.ReadLine() is not string fname)
                    throw new InvalidDataException("");
                Display(1, "FirstName", fname);
                return "FindUser";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindUser";
        }
    }
    private void Display(int i, string whereIt, string equalsTo)
    {
        List<Reviews>? review;
        int iCount = 0;
        List<User>? user = logic.DisplayAllUser();
        if (i == 1)
            user = logic.SearchUser(whereIt, equalsTo);

        Console.WriteLine("\nUsers: \n");
        if (user.Count > 0)
        {
            foreach (User u in user)
            {
                review = logicRev.DisplayReview("ReviewerId", u.ReviewerId);

                Console.WriteLine($"Name: {u.FirstName} {u.LastName}\tEmail: {u.Email}\n   User Account: {u.UserName}  ID:{u.ReviewerId}");
                foreach (Reviews re in review)
                {
                    iCount++;
                }
                if (review.Count == 0)
                    Console.WriteLine("User has not reviewed any Restaurants");
                else Console.WriteLine($"Number of Reviews: {iCount}");

                Console.WriteLine();
            }
        }
        else
            Console.WriteLine("User Not Found");
    }
}