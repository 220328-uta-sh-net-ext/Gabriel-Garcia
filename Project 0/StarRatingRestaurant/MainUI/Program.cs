using MainUI;

IMenu menu = new StartMenu();
bool bLoop = true;
while (bLoop)
{
    menu.Display();
    Console.Write("   > ");
    string sInput = Console.ReadLine();
    Console.Write("\n");


    switch (sInput)
    {
        case "Exit":
            bLoop = false;
            break;
        //--------------------StartManus----------------
        case "StartMenu":
            menu = new StartMenu();
            break;
        case "LoginUser":
            menu = new LoginUser();
            break;
        case "AddUser":
            menu = new AddUser();
            break;
        //--------------------UserManus----------------
        case "UserMenu":
            menu = new UserMenu();
            break;
        case "AdminMenu":
            menu = new AdminMenu();
            break;
        //--------------------AdminMenus-----------------
        case "FindUser":
            menu = new FindUser();
            break;
        case "AddRestaurant":
            menu = new AddRestaurant();
            break;
        //--------------------ActionMenus----------------
        case "AddReview":
            //menu = new AddReview();
            break;
        case "FindRestaurant":
            //menu = new FindRestaurant();
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;

    }
}