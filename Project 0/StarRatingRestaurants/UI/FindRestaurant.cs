using UI;
using BLogic;


internal class FindRestaurant : IMenus
{
    readonly IRestaurantLogic Rlogic;
    public FindRestaurant(IRestaurantLogic logic)
    { Rlogic = logic; }
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
                Console.Clear();

                //Find("", "");
                return "FindRateRestaurant";
            case "2":
                Console.Write("Enter ID: ");
                //  if (Console.ReadLine() is not string i)
                //      throw new InvalidDataException("");
                Console.Clear();
                //Find(i, "id");
                //sid = sId;
                return "FindRateRestaurant";
            case "3":
                Console.Write("Enter Zipcode: ");
                //  if (Console.ReadLine() is not string z)
                //     throw new InvalidDataException("");
                Console.Clear();
                //Find(z, "zipcode");
                return "FindRateRestaurant";
            case "4":
                Console.Write("Enter State: ");
                // if (Console.ReadLine() is not string s)
                //     throw new InvalidDataException("");
                Console.Clear();
                //Find(s, "state");
                return "FindRateRestaurant";
            case "5":
                Console.Write("Enter Country: ");
                // if (Console.ReadLine() is not string c)
                //     throw new InvalidDataException("");
                Console.Clear();
                //Find(c, "country");
                return "FindRateRestaurant";
            case "6":
                Console.Write("Enter Name: ");
                // if (Console.ReadLine() is not string n)
                //     throw new InvalidDataException("?");
                Console.Clear();
                //Find(n, "name");
                return "FindRateRestaurant";
            case "7":
                Console.Clear();
                /* if (sid != "")
                 {
                     int rate;
                     Console.WriteLine($"<1> <2> <3> <4> <5>: ");
                     Console.Write($"\nRate the Restaurant: ");
                     try
                     {
                         rate = Convert.ToInt32(Console.ReadLine());
                         if (rate > 0 && rate <= 5)
                         {
                             logic.RateRestaurant(sid, rate);
                             sid = "";
                             Log.Information($"User '{sName}' added a rateing {rate}");
                             Console.WriteLine("Your Review was Posted.");
                             return "FindRateRestaurant";
                         }
                         else { Console.WriteLine("Invalid input."); return "FindRateRestaurant"; }
                     }
                     catch (Exception ex) { Console.WriteLine(ex.Message); }

                     return "FindRateRestaurant";
                 }
                 else { Console.WriteLine("Invalid ID Found or Empty."); }
                */
                return "FindRateRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "FindRateRestaurant";
        }
    }
   /* private void Find()
    {
        List<MainML.Restaurant>? results = logic.DisplayRestaurant();
        results = logic.SearchRestaurant(name, n);
        Console.Clear();
        if (results.Count > 0)
        {
            foreach (MainML.Restaurant? r in results)
            {
                Console.WriteLine(r.ToString());
                if (r.ID == name)
                {
                    setID(name);
                }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");

        if (name == "" && n != "")
        { Console.WriteLine("\nYou Input '' so I printed all of them!"); }
    }*/
}