using MainUI;
using MainBL;
using MainML;
internal class AddRestaurant : IMenu
{
    static readonly Restaurant nRest = new();
    readonly IRestaurantLogic logic;

    public AddRestaurant(IRestaurantLogic logic)
    {
        this.logic = logic;
    }
    public void Display()
    {
        Console.WriteLine("-------- Adding Restaurant ---------\n");
        Console.WriteLine($"   <4> Restaurant's Name: {nRest.Name}");
        Console.WriteLine($"   <3> Add Location: {nRest.Country} {nRest.State} {nRest.Zipcode}");
        Console.WriteLine($"   <2> Type's: {nRest.TypeOf}");
        Console.WriteLine("   <1> Add Restaurant");
        Console.WriteLine("   <0> Go Back");
        Console.WriteLine("\n-----------------------------------\n");
    }

    public string UserChoice()
    {
        Console.Write("   > ");
        if (Console.ReadLine() is not string sInput)
            throw new InvalidDataException("");
        Console.Write("\n");
        DateTime localDate = DateTime.Now;
        switch (sInput)
        {
            case "0":
                Console.Clear();
                setInputToB();
                GC.Collect();
                return "AdminMenu";
            case "1":
                if(getMiss(nRest.Name,nRest.Country,nRest.State, nRest.Zipcode))
                {
                    nRest.ID = localDate.Year.ToString() + localDate.Day + localDate.Month + nRest.Name.Length + localDate.Minute + localDate.Second + nRest.Name.ToUpper().First();
                    List<MainML.Restaurant>? restaurants = logic.DisplayRestaurant();
                    restaurants = logic.SearchRestaurant(nRest.ID, "id");
                    {
                        foreach(MainML.Restaurant? r in restaurants)
                        {
                            if (r.ID == nRest.ID)
                            {
                                Console.WriteLine("Please try agen in a few seconds, as the id made was found in the database.");
                                return "AddRestaurant";
                            }
                        }
                        try
                        {
                            logic.AddRestaurant(nRest);
                        }
                        catch (Exception ex)
                        { Console.WriteLine(ex.Message); }

                    }
                }
                else
                {
                    printMiss(nRest.Name, nRest.Country, nRest.State, nRest.Zipcode);
                    return "AddUser";
                }
                Console.WriteLine("Restaurant Added to the Database.\n");
                Console.Write("\n\tPress <enter> to continue\n   >");
                Console.ReadLine(); 
                setInputToB();
                GC.Collect();
                Console.Clear();
                return "AddRestaurant";
            case "2":

                Console.Write("Types:\t<Fine Dining> <Casual Dining> <Family Style> <Fast Food>\n\t<Food Trusk, Cart or Stand> <Cafe> <Pub> <Coffee House> <Diner>...\n");
                Console.Write("Enter type: ");
                nRest.TypeOf = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            case "3":
                Console.WriteLine("If Not Applicable Input <none>");
                Console.Write("Enter Contry: ");
                nRest.Country = Console.ReadLine();
                Console.Write("Enter State/Provinces: ");
                nRest.State = Console.ReadLine();
                Console.Write("Enter Zipcode: ");
                nRest.Zipcode = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            case "4":
                Console.Write("Enter Name: ");
                nRest.Name = Console.ReadLine();
                Console.Clear();
                return "AddRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "AddRestaurant";
        }
    }
    private void setInputToB()
    {
        nRest.NReview = 0;
        nRest.Review = 0;
        nRest.ID = "";
        nRest.Name = "";
        nRest.State = "";
        nRest.Country = "";
        nRest.Zipcode = "";
    }
    private bool getMiss(string n, string c, string s, string z)
    {
        if (n == "")
            return false;
        else if (c == "")
            return false;
        else if (s == "")
            return false;
        else if (z == "")
            return false;
        else
            return true;

    }
    private void printMiss(string n, string c, string s, string z)
    {
        string miss = "";
        if (n == "")
            miss += " (Name) ";
        if (c == "")
            miss += " (Country) ";
        if (s == "")
            miss += " (State/Territory) ";
        if (z == "")
            miss += " (Zipcode) ";

        Console.WriteLine($"Missing {miss}");
    }
}