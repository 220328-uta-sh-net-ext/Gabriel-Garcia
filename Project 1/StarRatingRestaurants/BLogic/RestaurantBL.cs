using Models;
using DatabaseL;

namespace BLogic
{
    public class RestaurantBL : IRestaurantLogic
    {
        readonly IRepositoryR repo;
        public RestaurantBL(IRepositoryR repo)
        {
            this.repo = repo;
        }
        public Restaurant AddRestaurant(Restaurant r)
        {
            return repo.AddRestaurant(r);
        }
        public void DeleteRestaurant(string id)
        {
            repo.DeleteRestaurant(id);
        }
        public List<Restaurant> SearchRestaurant(string table, string type, string value)
        {
            List<Restaurant>? restaurants = repo.DisplayRestaurants(table,type,value);
            return restaurants;
        }

    }
}