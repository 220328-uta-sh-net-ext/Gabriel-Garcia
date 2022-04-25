using RestaurantUI;
MainMenu menu = new MainMenu();
bool bLoop = true;

menu.DisplayStartMenu();
bool logingin= true;
string sGetInput;
while(bLoop)
{
    if (logingin)
        sGetInput = menu.UserChoiceLogingin();
    else 
        sGetInput = menu.UserChoiceLogedin();

    switch (sGetInput)
    {
        case "Exit":
            bLoop = false;
            break;
        case "LoginMenu":
            //do this
            break;
        case "Loggin User":
            //do this;
            break;
        case "Create User":
            //do this
            break;
        case "DisplayRestaurant":
            //do this
            break;
        case "UserMenu":
            //do this
            break;
        case "DeleteAccount":
            //do this;
            break;
        case "Restaurant as User":
            //do this
            break;
        case "Request a Restaurant":
            //do this
            break;
        case "view details of Restaurant":
            //do this
            break;
        case "view reviews of Restaurant":
            //do this
            break;
        case "find a Restaurant":
            //do this
            break;
        case "AdminMenu":
            //do this
            break;
        case "Admin search user":
            //do this
            break;
        case "Restaurant Menu":
            //do this
            break;
        case "Add a Restaurant":
            //do this
            break;
        case "Add a Restaurant Requested":
            //do this
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}
