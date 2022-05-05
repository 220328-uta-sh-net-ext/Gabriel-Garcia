using Models;

namespace DL
{
    public interface IRepositoryR
    {
        Restaurant AddRestaurant(Restaurant rest);
        List<Restaurant> DisplayRestaurants(string table, string type, string val);
        void DeleteRestaurant(string id);
    }
    public interface IRepositoryU
    {
        User AddUser(User user);
        List<User> DisplayUser(string name);
        void DeleteUser(string user, string id);
    }
}
