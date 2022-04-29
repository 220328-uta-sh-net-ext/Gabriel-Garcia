using System.Collections.Generic;
using RestaurantML;

namespace RestaurantDL
{
    public interface IRestaurantRepo
    {
        Restaurant AddRestaurant(Restaurant rest);
        Restaurant AddReview(Restaurant rest);
        List<Restaurant> GetAllRestaurants();
    }
}
