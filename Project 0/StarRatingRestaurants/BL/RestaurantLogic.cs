using DL;
using Models;

namespace BL
{
    public class RestaurantLogic : IRestaurantLogic, IReviewLogic
    {
        readonly IRepositoryR repo;
        readonly IRepositoryRev repoRev;
        public RestaurantLogic(IRepositoryR repo, IRepositoryRev repoRev)
        {
            this.repo = repo;
            this.repoRev = repoRev;
        }
        public Restaurant AddRestaurant(Restaurant r)
        {
            return repo.AddRestaurant(r);
        }
        public void DeleteRestaurant(string id)
        {
            repo.DeleteRestaurant(id);
            repoRev.DeleteReviews("Id", id);
        }

        public List<Reviews> DisplayReview(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = repoRev.DisplayReviews(whereIt, equalsTo);
            return reviews;
        }
        public List<Restaurant> SearchRestLocation(string whereIt, string equalsTo)
        {
            List<Restaurant>? restaurants = repo.SearchRestLocation(whereIt, equalsTo);
            return restaurants;
        }
        public List<Restaurant> SearchRestaurant( string whereIt, string equalsTo)
        {
            List<Restaurant>? restaurants = repo.SearchRestaurants(whereIt, equalsTo);
            return restaurants;
        }
        public List<Restaurant> DisplayAllRestaurants()
        {
            List<Restaurant>? restaurants = repo.DisplayAllRestLocation();
            return restaurants;
        }

        public void DeleteReview(string whereIt, string equalsTo, string whereItU, string equalsToU)
        {
            repoRev.DeleteReviews(whereIt, equalsTo,whereItU,equalsToU);
        }
    }
}