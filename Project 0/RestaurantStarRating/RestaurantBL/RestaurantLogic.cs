using RestaurantDL;
using RestaurantML;

namespace RestaurantBL
{
    public class RestaurantLogic : IRestaurantLogic
    {
        IRestaurantRepo repo = new RestaurantRepo();
        public Restaurant AddRestaurant(Restaurant r)
        {
            return repo.AddRestaurant(r);
        }

        public List<Restaurant> SearchRestaurant(string name, string id)
        {
            var vRestaurant = repo.GetAllRestaurants();
            var vfilteredRestaurant = vRestaurant.Where(r => r.sName.Contains(name)).ToList();
            return vfilteredRestaurant;
        }
    }
}