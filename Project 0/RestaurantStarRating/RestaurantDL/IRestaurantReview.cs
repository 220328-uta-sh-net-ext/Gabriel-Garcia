using System.Collections.Generic;
using RestaurantsUser;

namespace RestaurantDL
{
    public interface IRestaurantReview
    {
        RUMain AddRestaurant(RUMain Restaurant);
        List<RUMain> GetAllPokemons();
    }
}
