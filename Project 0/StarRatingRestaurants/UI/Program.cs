global using Serilog;
using BL;
using DL;
using UI;

IMenus menu = new StartMenu();
string connectinStrringFilePath = "../../../../SQLConnection.txt";
string connectinStrring = File.ReadAllText(connectinStrringFilePath);

IRepositoryRev repoRev = new RepoReview(connectinStrring);

IRepositoryU repoU = new RepoUsers(connectinStrring);
IUserLogic Ulogic = new UserLogic(repoU,repoRev);
IRepositoryR repoR = new RepoRestaurants(connectinStrring);
IRestaurantLogic Rlogic = new RestaurantLogic(repoR, repoRev);
IReviewLogic logicR = new RestaurantLogic(repoR, repoRev);

//Log.Logger = new LoggerConfiguration().WriteTo.File("./Logs/user.text").CreateLogger();

//IMainLogic Ulogic = new UserLogic(RepositoryU);
bool loop = true;

while (loop)
{
    menu.DisplayOptions();
    string sInput = menu.GetSendOptions();


    switch (sInput)
    {
        case "Exit":
            loop = false;
            break;
        //--------------------StartManus----------------
        case "StartMenu":
            menu = new StartMenu();
            break;
        case "LoginUser":
            menu = new LoginUser(Ulogic);
            break;
        case "CreateUser":
            menu = new CreateUser(Ulogic);
            break;
        case "FindRestaurant":
            menu = new FindRestaurant(Rlogic, logicR);
            break;
        //--------------------UserManus----------------
        case "UserMenu":
            //menu = new UserMenu();
            break;
        case "AdminMenu":
            //menu = new AdminMenu();
            break;
        //--------------------AdminMenus-----------------
        case "FindUser":
            //menu = new FindUser(Ulogic);
            break;
        case "AddRestaurant":
            //menu = new AddRestaurant(Rlogic);
            break;
        //--------------------ActionMenus----------------
        case "AddReview":
            //menu = new AddReview();
            break;
        case "FindRateRestaurant":
            //menu = new FindAndRateRestaurant(Rlogic);
            break;
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;

    }
}