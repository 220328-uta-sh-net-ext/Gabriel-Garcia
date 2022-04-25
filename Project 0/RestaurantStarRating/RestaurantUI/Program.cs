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
        case "Loggin User":
            GetRestReview.GetAllRestorant();
            break;
        case "Create User":
            GetRestReview.GetAllRestorant();
            break;
        case "DisplayRestaurant":
            GetRestReview.GetAllRestorant();
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}