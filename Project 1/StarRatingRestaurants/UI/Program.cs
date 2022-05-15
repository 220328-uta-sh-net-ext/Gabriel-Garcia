global using Serilog;
using BL;
using DL;
using UI;

IMenus menu = new StartMenu();
string connectinStrringFilePath = "../../../../SQLConnection.txt";
string connectinStrring = File.ReadAllText(connectinStrringFilePath);

IRepositoryRev repoRev = new RepoReview(connectinStrring);
//user logic
IRepositoryU repoU = new RepoUsers(connectinStrring);
IUserLogic Ulogic = new UserLogic(repoU,repoRev);
//restaurant logic
IRepositoryR repoR = new RepoRestaurants(connectinStrring);
IRestaurantLogic Rlogic = new RestaurantLogic(repoR, repoRev);
//restaruant and review logic
IReviewLogic logicR = new RestaurantLogic(repoR, repoRev);
//restaruant and review logic
IReviewLogic logicUR = new UserLogic(repoU, repoRev);
//restaruant and review logic



Log.Logger = new LoggerConfiguration().WriteTo.File("./Logs/user.text").CreateLogger();
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
        //--------------------UserManus----------------
        case "UserMenu":
            menu = new UserMenu(Ulogic);
            break;
        case "AdminMenu":
            menu = new AdminMenu();
            break;
        //--------------------AdminMenus-----------------
        case "FindUser":
            menu = new FindUser(Ulogic, logicUR);
            break;
        case "AddRestaurant":
            menu = new AddRestaurant(Rlogic);
            break;
        case "DeleteRestaurant":
            menu = new DeleteRestaurant(Rlogic);
            break;
        //--------------------AllUserAction--------------
        case "FindRestaurant":
            menu = new FindRestaurant(Rlogic, logicR);
            break;
        case "RateRestaurant":
            menu = new RateRestaurant(Ulogic,logicUR,Rlogic);
            break;
        //-----------------------------------------------
        default:
            Console.WriteLine("invalide input...");
            Console.ReadLine();
            break;
    }
}      