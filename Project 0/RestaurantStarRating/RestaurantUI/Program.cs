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
        case "Login User":
            menu = new LogInUser();
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
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
