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
        //void PrintTheRestaurantToRate(string name, string id);
        void SearchRestaurant();
        void SearchRestaurant(string sType, string sContry, string sState, string sZip, string name, string id);
        void PrintRateRestaurant(string n, string i);

    }
    interface IRestaurantSearch
    {
        List<Restaurant> SearchAllRestaurant();
    }
}
