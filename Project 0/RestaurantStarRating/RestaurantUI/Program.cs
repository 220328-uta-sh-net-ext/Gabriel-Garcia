using RestaurantUI;
IMenu menu = new MainMenu();
bool bLoop = true;

//bool logingIn = true;
//bool isAdmin = false;
while(bLoop)
{
    menu.Display();
    string sGetInput = menu.UserChoice();
    /*if (!logingIn && isAdmin)
        sGetInput = menu.AdminUserLoggin();
    else if(!logingIn && !isAdmin)
        sGetInput = menu.UserChoiceLogedin();
    else
        sGetInput = menu.UserChoiceLogingin();*/


    switch (sGetInput)
    {
        case "Exit":
            bLoop = false;
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "Loggin User":
            break;
        case "Create User":
            menu = new AddUser();
            break;
        case "Add Restaurant":
            menu = new AddRestaurant();
            break;
        case "Add Location":
            menu = new AddLocationForRestaurant();
            break;
        /*case "Add Location":
            //menu.DisplayUserMenu();
            break;
        case "Rate a Restaurant":
            Console.WriteLine($"sedding user to rate rest..");
            //GetRestReview.GetAllRestorant();
            break;
        case "Restaurant's Review":
            Console.WriteLine($"sedding user to restaurants rev..");
            break;
        case "Restaurant's Detail":
            Console.WriteLine($"sedding user to restaurants de..");
            break;
        case "Edit Account":
            Console.WriteLine($"sedding user to restaurants de..");
            break;
        case "AdminMenu":
            //menu.DisplayAdminMenu();
            break;
        case "Add a Restaurant":
            Console.WriteLine($"adding a Restaurant");
            break;
        case "Search User":
            Console.WriteLine($"looking for a user");
            break;
        case "See All User":
            Console.WriteLine($"see all users");
            break;*/
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
