using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantML;

namespace RestaurantBL
{
    public interface IRestaurantLogic
    {
        Restaurant AddRestaurant(Restaurant r);
        List<Restaurant> SearchRestaurant(string name,string id);
    }
    interface IRestaurantSearch
    {
        List<Restaurant> SearchAllRestaurant();
    }
}
