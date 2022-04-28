using RestaurantUI;
IMenu menu = new MainMenu();
bool bLoop = true;

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
            menu = new MainMenu();
            break;
        case "Login User":
            menu = new LogInUser();
            break;
        //--------------------UserManus----------------
        case "User Menu":
            menu = new UserMenu();
            break;
        case "Admin Menu":
            menu = new UserMenuAdmin();
            break;
        //--------------------ActionMenus----------------
        case "AddReview":
            menu = new AddReview();
            break;
        case "FindRestaurant":
            menu = new FindRestaurant();
            break;
        case "FindUser":
            menu = new FindUser();
            break;
        case "DisplayRestaurant":
            menu = new DisplayRestaurant();
            break;
        //--------------------AddItems----------------
        case "Create User":
            menu = new AddUser();
            break;
        case "Add Restaurant":
            menu = new AddRestaurant();
            break;
        case "Add Location":
            menu = new AddLocationForRestaurant();
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
