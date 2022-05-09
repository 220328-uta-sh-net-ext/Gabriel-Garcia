using Models;

namespace DL
{
    public interface IRepositoryR
    {
        Restaurant AddRestaurant(Restaurant rest);
        List<Restaurant> SearchRestaurants(string WhereIt, string equalsTo);
        List<Restaurant> SearchRestLocation(string WhereIt, string equalsTo);
        List<Restaurant> DisplayAllRestLocation();
        void DeleteRestaurant(string id);
    }
    public interface IRepositoryU
    {
        User AddUser(User user);
        List<User> DisplayUser(string WhereIt, string equalsTo);
        void DeleteUser(string user);
    }
    public interface IRepositoryRev
    {
        Reviews AddReviews(Reviews user);
        List<Reviews> DisplayReviews(string WhereIt, string equalsTo);
        void DeleteReviews(string WhereIt, string EqualsTo);
    }
}
