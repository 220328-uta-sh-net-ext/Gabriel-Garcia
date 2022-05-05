using Models;

namespace BL
{
    public interface IRestaurantLogic
    {
        Restaurant AddRestaurant(Restaurant r);
        List<Restaurant> SearchRestaurant(string table, string type, string value);
        void DeleteRestaurant(string id);
    }
    public interface IUserLogic
    {
        //User AddUser(User u);
        //List<User> SearchUser(string name, string c);
        //string LogUser(string name, string pass);
        //void PrintTheRestaurantToRate(string name, string id);
        //List<User> DisplayUser();
    }
}
