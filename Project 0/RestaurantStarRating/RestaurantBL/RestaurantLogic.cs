using RestaurantDL;
using RestaurantML;

namespace RestaurantBL
{
    public class RestaurantLogic : IRestaurantLogic
    {
        IRestaurantRepo repo = new RestaurantRepo();
        public Restaurant AddRestaurant(Restaurant r)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> SearchRestaurant(string name, string id)
        {
            throw new NotImplementedException();
        }
    }
}