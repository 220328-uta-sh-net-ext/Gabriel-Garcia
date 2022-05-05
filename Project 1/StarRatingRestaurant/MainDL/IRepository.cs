using MainML;
namespace MainDL
{
    public interface IRepositoryR
    {
        Restaurant AddRestaurant(Restaurant rest);
        void AddReview(string id, int rev);
        List<Restaurant> GetAllRestaurants();
    }
    public interface IRepositoryU
    {
        User AddUser(User uUser);
        List<User> GetAllUser();
        List<User> GetLogUser();
    }
}
