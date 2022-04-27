using RestaurantDL;
using RestaurantML;

namespace RestaurantUI
{
    internal class GetRestReview
    {
        private static RestaurantRepo repository = new RestaurantRepo();
        public static void GetAllRestaurant()
        {
            var vRestaurant = repository.GetAllRestaurants();
            foreach(var rest in vRestaurant)
            {
                Console.WriteLine($"{rest.Name} {rest.Review}");
            }
        }

    }
}
