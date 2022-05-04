using Models;
using DatabaseL;
namespace BLogic
{
    public class RestaurantBL //: //IRestaurantLogic
    {
        readonly IRepositoryR _logic;
        public RestaurantBL(IRepositoryR repo)
        {
            _logic = repo;
        }
        //public List<Restaurant> DisplayRestaurant()
       // {
            ///List<Restaurant> restaurant = _logic.DisplayRestaurant();
            //return restaurant;
       // }
        public void FindRestaurants()
        {
            //foreach (Restaurant restaurant in DisplayRestaurant())
           // {
                
           // }
        }
        /* private void Find()
 {
     List<MainML.Restaurant>? results = logic.DisplayRestaurant();
     results = logic.SearchRestaurant(name, n);
     Console.Clear();
     if (results.Count > 0)
     {
         foreach (MainML.Restaurant? r in results)
         {
             Console.WriteLine(r.ToString());
             if (r.ID == name)
             {
                 setID(name);
             }
         }
     }
     else
         Console.WriteLine("Restaurant Not Found");

     if (name == "" && n != "")
     { Console.WriteLine("\nYou Input '' so I printed all of them!"); }
 }*/
    }
}