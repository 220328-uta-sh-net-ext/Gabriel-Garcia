﻿using Models;

namespace BL
{
    public interface IRestaurantLogic
    {
        Restaurant AddRestaurant(Restaurant r);
        List<Restaurant> SearchRestaurant(string whereIt, string equalsTo);
        List<Restaurant> DisplayAllRestaurants();
        void DeleteRestaurant(string id);
        // async
        Task<Restaurant> AddRestaurantAsync(Restaurant r);
        Task<List<Restaurant>> SearchRestaurantAsync(string whereIt, string equalsTo);
        Task<List<Restaurant>> DisplayAllRestaurantsAsync();
        Task<List<Type>> TDisplayAllRestaurantsAsync();
    }
    public interface IUserLogic
    {
        User AddUser(User u);
        Reviews AddReviews(Reviews rev);
        List<User> SearchUser(string whereIt, string equalsTo);
        List<User> DisplayAllUser();
        void DeleteUser(string user,string id);
        string LogingIn(string user,string pass);
        // async
        Task<User> AddUserAsync(User u);
        Task<Reviews> AddReviewsAsync(Reviews rev);
        Task<List<User>> SearchUserAsync(string whereIt, string equalsTo);
        Task<List<User>> DisplayAllUserAsync();

    }
    public interface IReviewLogic
    {
        void DeleteReview(string whereIt, string equalsTo, string whereItU, string equalsToU);
        List<Reviews> DisplayReview(string whereIt, string equalsTo);
        // async
        Task<List<Reviews>> DisplayReviewAsync(string whereIt, string equalsTo);
    }
    public interface ILocationLogic
    {
        void DeleteLocation(string equalsTo);
        List<Location> DisplayAllRestLocation();
        List<Location> SearchRestLocation(string whereIt, string equalsTo);
        Task<List<Location>> SearchRestLocationAsync(string whereIt, string equalsTo);
        Task<List<Location>> DisplayAllRestLocationAsync();
    }
}
