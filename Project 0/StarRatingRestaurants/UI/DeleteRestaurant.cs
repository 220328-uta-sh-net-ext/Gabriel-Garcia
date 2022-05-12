using BL;
using Models;
using UI;

internal class DeleteRestaurant : IMenus
{
    static readonly Restaurant rest = new();
    readonly IRestaurantLogic logic;
    private static bool checktoDelete;
    public DeleteRestaurant(IRestaurantLogic logic)
    {
        this.logic = logic;
    }
    public void DisplayOptions()
    {
        Console.WriteLine("----------- Admin Menu -----------\n");
        Console.WriteLine("   <4> Set to Delete:");
        Console.WriteLine("   <3> Filter by Name:");
        Console.WriteLine("   <2> Display All Restaurants");
        Console.WriteLine("   <1> Delete Restaurant: ");
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
                if (checktoDelete)
                {
                    logic.DeleteRestaurant(rest.Id);
                    Console.WriteLine($"Deleted {rest.Id}");
                    checktoDelete = false;
                }
                else Console.WriteLine("No Restaurant was set to be delete.");
                return "DeleteRestaurant";
            case "2":
                Console.Clear();
                Display(0, "", "");
                return "DeleteRestaurant";
            case "3":
                string name = Console.ReadLine();
                if (name == null) name = "";
                Display(1, "Name",name);
                return "DeleteRestaurant";
            case "4":
                string id = Console.ReadLine();
                if (id == null) id = "";
                SetToDelete("Id", id);
                return "DeleteRestaurant";
            default:
                Console.Clear();
                Console.WriteLine($"Your input '{sInput}' is invalid!");
                return "Login User";
        }
    }
    private void Display(int i, string whereIt, string equalsTo)
    {

        List<Restaurant>? restaurant = logic.DisplayAllRestaurants();
        if (i == 1)
            restaurant = logic.SearchRestaurant(whereIt, equalsTo);


        List<Restaurant>? restLocation;
        Console.WriteLine("\nRestaurant\n");
        if (restaurant.Count > 0)
        {
            foreach (Restaurant r in restaurant)
            {
                restLocation = logic.SearchRestLocation("Id", r.Id);
                foreach (Restaurant l in restLocation)
                {
                    Console.WriteLine($"Name: {r.Name}\tID: {r.Id}\n   Location: {l.Country} {l.State} {l.City} {l.Zipcode}");
                    Console.WriteLine();
                }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");
    }
    private void SetToDelete(string whereIt, string equalsTo) 
    {

        List<Restaurant>? restaurant = logic.SearchRestaurant(whereIt, equalsTo);
        List<Restaurant>? restLocation;
        Console.WriteLine("\nRestaurant\n");
        if (restaurant.Count > 0 && restaurant.Count == 1)
        {
            foreach (Restaurant r in restaurant)
            {
                restLocation = logic.SearchRestLocation("Id", r.Id);
                foreach (Restaurant l in restLocation)
                {
                    Console.WriteLine($"*** {checktoDelete}");
                    Console.Write($"\n\n Would you like to delete?\n\n Restaurant: {r.Name}\tID: {r.Id}\n Located at:{l.Country} {l.State} {l.City} {l.Zipcode}\n\n\t>");
                    string getInput = Console.ReadLine();
                    if (getInput == "Yes" || getInput == "Y" || getInput == "y") { rest.Id = r.Id; checktoDelete = true; }
                    else if(getInput == null) checktoDelete = false;
                    else checktoDelete = false;
                    Console.WriteLine($"*** {checktoDelete}");
                }
            }
        }
        else
            Console.WriteLine("Restaurant Not Found");
        
    }
}