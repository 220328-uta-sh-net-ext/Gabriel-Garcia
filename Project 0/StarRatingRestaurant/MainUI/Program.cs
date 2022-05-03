global using Serilog;

using MainUI;
using MainDL;
using MainBL;

IMenu menu = new StartMenu();
string connectinStrringFilePath = "../../../../SQLConnection.txt";
string connectinStrring = File.ReadAllText(connectinStrringFilePath);
IRepositoryU repoU = new RepositoryU(connectinStrring);
IUserLogic Ulogic = new UserLogic(repoU);
IRepositoryR repoR = new RepositoryR(connectinStrring);
IRestaurantLogic Rlogic = new RestaurantLogic(repoR);

//Log.Logger = new LoggerConfiguration().WritTo.File("./Logs/user.text").CreateLogger();

//IMainLogic Ulogic = new UserLogic(RepositoryU);
bool bLoop = true;
while (bLoop)
{
    menu.Display();
    string sInput = menu.UserChoice();


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
            menu = new LoginUser(Ulogic);
            break;
        case "AddUser":
            menu = new AddUser(Ulogic);
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
            menu = new FindUser(Ulogic);
            break;
        case "AddRestaurant":
            menu = new AddRestaurant(Rlogic);
            break;
        //--------------------ActionMenus----------------
        case "AddReview":
            //menu = new AddReview();
            break;
        case "FindRateRestaurant":
            menu = new FindAndRateRestaurant(Rlogic);
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;

    }
}