using RestaurantDL;

namespace RestaurantUI
{
    internal class GetRestReview
    {
        private static RestaurantRepo repository = new RestaurantRepo();
        public static void GetAllRestorant()
        {
            repository.GetAllRestaurants();
        }
    }
}
