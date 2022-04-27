using RestaurantUI;
MainMenu menu = new MainMenu();
bool bLoop = true;

menu.Display();
//bool logingIn = true;
//bool isAdmin = false;
string sGetInput;
while(bLoop)
{
    sGetInput = menu.UserChoice();
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
        case "LoginMenu":
            //menu.DisplayStartMenu();
            //logingIn = true;
            break;
        case "Loggin User":
            Console.WriteLine($"logging in to user");
            //logingIn = false;
            //isAdmin = true;
            break;
        case "Create User":
            Console.WriteLine($"creating user");
            break;
        case "UserMenu":
            //menu.DisplayUserMenu();
            break;
        case "Rate a Restaurant":
            Console.WriteLine($"sedding user to rate rest..");
            GetRestReview.GetAllRestorant();
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
            menu.DisplayAdminMenu();
            break;
        case "Add a Restaurant":
            Console.WriteLine($"adding a Restaurant");
            break;
        case "Search User":
            Console.WriteLine($"looking for a user");
            break;
        case "See All User":
            Console.WriteLine($"see all users");
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
