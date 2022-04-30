global using Serilog;
using RestaurantUI;
IMenu menu = new MainMenu();
bool bLoop = true;

Log.Logger = new LoggerConfiguration().WriteTo.File("./Logs/user.txt").CreateLogger();

while(bLoop)
{
    menu.Display();
    string sGetInput = menu.UserChoice();


    switch (sGetInput)
    {
        case "Exit":
            bLoop = false;
            break;
        //--------------------MainManus----------------
        case "MainMenu":
            Log.Debug("user back");
            menu = new MainMenu();
            break;
        case "Login User":
            Log.Debug("user back");
            menu = new LogInUser();
            break;
        //--------------------UserManus----------------
        case "User Menu":
            Log.Debug("user back");
            menu = new UserMenu();
            break;
        case "Admin Menu":
            Log.Debug("user back");
            menu = new UserMenuAdmin();
            break;
        //--------------------ActionMenus----------------
        case "AddReview":
            Log.Debug("user back");
            menu = new AddReview();
            break;
        case "FindRestaurant":
            Log.Debug("user back");
            menu = new FindRestaurant();
            break;
        case "FindUser":
            menu = new FindUser();
            break;
        //--------------------AddItems----------------
        case "Create User":
            Log.Debug("user back");
            menu = new AddUser();
            break;
        case "Add Restaurant":
            Log.Debug("user back");
            menu = new AddRestaurant();
            break;
        case "Add Location":
            Log.Debug("user back");
            menu = new AddLocationForRestaurant();
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
