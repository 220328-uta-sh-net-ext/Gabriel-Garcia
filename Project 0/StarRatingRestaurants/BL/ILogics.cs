using Models;

namespace BL
{
    public interface IRestaurantLogic
    {
        Restaurant AddRestaurant(Restaurant r);
        List<Restaurant> SearchRestaurant(string whereIt, string equalsTo);
        List<Restaurant> SearchRestLocation(string whereIt, string equalsTo);
        List<Restaurant> DisplayAllRestaurants();
        void DeleteRestaurant(string id);
    }
    public interface IUserLogic
    {
        User AddUser(User u);
        Reviews AddReviews(Reviews rev);
        List<User> SearchUser(string whereIt, string equalsTo);
        List<User> DisplayAllUser();
        void DeleteUser(string user,string id);
    }
    public interface IReviewLogic
    {
        List<Reviews> DisplayReview(string whereIt, string equalsTo);
    }
}
