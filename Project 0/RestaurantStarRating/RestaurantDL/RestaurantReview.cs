using RestaurantsUser;
using System.IO;

namespace RestaurantDL
{
    public class RestaurantReview : IRestaurantReview
    {
        private string filePath = "../RestaurantDL/Datatbase/";
        private string title = "";
        public RUMain AddRestaurant(RUMain Restaurant)
        {
            throw new NotImplementedException();
        }

        public List<RUMain> GetAllPokemons()
        {
            title = File.ReadAllText(filePath+"ListOfRestaurants.json");
            return new List<RUMain>();
        }
    }
}