using System.Collections.Generic;
using RestaurantML;

namespace RestaurantDL
{
    internal interface IRestaurantRepo
    {
        Restaurant AddRestaurant(Restaurant rest);
        List<Restaurant> GetAllRestaurants();
    }
}
