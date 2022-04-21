using RestaurantUI;

Menu menu = new MainMenu();
bool repeat = true;

menu.Display();
while (repeat)
{
    string ans = menu.UserChoice();

    switch(ans)
    {
        case "Loggin":
            Console.WriteLine("Login...");
            break;
        case "New User":
            Console.WriteLine("Creating new User...");
            break;
        case "MainMenu":
            menu = new MainMenu();
            menu.Display();
            break;
        case "PrintRestaurantList":
            menu = new MainMenu();
            menu.Display();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}