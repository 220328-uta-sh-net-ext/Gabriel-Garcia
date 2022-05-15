using Models;

namespace DL
{
    public interface IRepositoryR
    {
        Restaurant AddRestaurant(Restaurant rest);
        List<Restaurant> DisplayAllRestaurant();
        List<Restaurant> SearchRestaurants(string WhereIt, string equalsTo);
        List<Restaurant> SearchRestLocation(string WhereIt, string equalsTo);
        void DeleteRestaurant(string id);
        // A-Sync
        Task<Restaurant> AddRestaurantAsync(Restaurant rest);
        Task<List<Restaurant>> DisplayAllRestaurantAsync();
        Task<List<Restaurant>> SearchRestaurantsAsync(string WhereIt, string equalsTo);
        Task<List<Restaurant>> SearchRestLocationAsync(string WhereIt, string equalsTo);
    }
    public interface IRepositoryU
    {
        User AddUser(User user);
        List<User> SearchUser(string WhereIt, string equalsTo);
        List<User> DisplayAllUser();
        void DeleteUser(string user);
        // A-Sync
        Task<User> AddUserAsync(User user);
        Task<List<User>> SearchUserAsync(string WhereIt, string equalsTo);
        Task<List<User>> DisplayAllUserAsync();
    }
    public interface IRepositoryRev
    {
        Reviews AddReviews(Reviews user);
        List<Reviews> DisplayReviews(string WhereIt, string equalsTo);
        void DeleteReviews(string WhereIt, string EqualsTo,string WhereItU, string EqualsToU);
        void DeleteReviews(string WhereIt, string EqualsTo);
        // A-Sync
        Task<Reviews> AddReviewsAsync(Reviews user);
        Task<List<Reviews>> DisplayReviewsAsync(string WhereIt, string equalsTo);

    }
}
