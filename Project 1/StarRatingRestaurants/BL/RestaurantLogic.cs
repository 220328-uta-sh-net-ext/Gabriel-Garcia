using DL;
using Models;

namespace BL
{
    public class RestaurantLogic : IRestaurantLogic, IReviewLogic, ILocationLogic
    {
        readonly IRepositoryR repo;
        readonly IRepositoryRev repoRev;
        readonly IRepositoryLoc repoLoc;
        public RestaurantLogic(IRepositoryR repo, IRepositoryRev repoRev, IRepositoryLoc repoLoc)
        {
            this.repo = repo;
            this.repoRev = repoRev;
            this.repoLoc = repoLoc; 
        }
        public void AddRestaurant(Restaurant r, Location l)
        {
            repo.AddRestaurant(r);
            repoLoc.AddRestLocation(l);
            
        }
        public void DeleteRestaurant(string id)
        {
            repoLoc.DeleteRestLocation(id);
            repoRev.DeleteReviews("Id", id);
            repo.DeleteRestaurant(id);
        }
        public List<Reviews> DisplayReview(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = repoRev.DisplayReviews(whereIt, equalsTo);
            return reviews;
        }
        public List<Location> SearchRestLocation(string whereIt, string equalsTo)
        {
            List<Location>? locations = repoLoc.SearchRestLocation(whereIt, equalsTo);
            return locations;
        }
        public List<Restaurant> SearchRestaurant( string whereIt, string equalsTo)
        {
            List<Restaurant>? newRestaurant = new List<Restaurant>();
            List<Restaurant>? restaurants = repo.SearchRestaurants(whereIt, equalsTo);
            foreach (var r in restaurants)
            {
                List<Location>? locations = repoLoc.SearchRestLocation("Id", r.Id);
                foreach (var l in locations)
                {
                    List<Reviews>? reviews = repoRev.DisplayReviews("Id", r.Id);
                    newRestaurant.Add(new Restaurant
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Locations = locations,
                        Reviews = reviews
                    });
                }
            }
            return newRestaurant;
        }
        public List<Restaurant> DisplayAllRestaurants()
        {
            List<Restaurant>? newRestaurant = new List<Restaurant>();
            List<Restaurant>? restaurants = repo.DisplayAllRestaurant();
            foreach (var r in restaurants)
            {
                List<Location>? locations = repoLoc.SearchRestLocation("Id",r.Id);
                foreach (var l in locations)
                {
                    List<Reviews>? reviews = repoRev.DisplayReviews("Id", r.Id);
                    newRestaurant.Add(new Restaurant
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Locations = locations,
                        Reviews = reviews
                    });
                }
            }
            return newRestaurant;
        }
        public void DeleteReview(string whereIt, string equalsTo, string whereItU, string equalsToU)
        {
            repoRev.DeleteReviews(whereIt, equalsTo,whereItU,equalsToU);
        }
        //----------------Async-----------------------
        public async Task<Restaurant> AddRestaurantAsync(Restaurant r)
        {
            return await repo.AddRestaurantAsync(r);
        }

        public async Task<List<Restaurant>> SearchRestaurantAsync(string whereIt, string equalsTo)
        {
            List<Restaurant>? restaurants = await repo.SearchRestaurantsAsync(whereIt, equalsTo);
            return restaurants;
        }

        public async Task<List<Location>> SearchRestLocationAsync(string whereIt, string equalsTo)
        {
            List<Location>? location = await repoLoc.SearchRestLocationAsync(whereIt, equalsTo);
            return location;
        }

        /*public async Task<List<Restaurant>> DisplayAllRestaurantsAsync()
        {
            List<Restaurant>? restaurants = await repo.DisplayAllRestaurantAsync();
            return restaurants;
        }*/
        public async Task<List<Restaurant>> DisplayAllRestaurantsAsync()
        {
            List<Restaurant>? newRestaurant = new List<Restaurant>();
            List<Restaurant>? restaurants = await repo.DisplayAllRestaurantAsync();
            List<Location>? locations = await repoLoc.DisplayAllRestLocationAsync();
            while (restaurants.Count > 0) 
            { 
                foreach (var r in restaurants)
                {
                    foreach (var l in locations)
                    {
                        List<Reviews>? reviews = await repoRev.DisplayReviewsAsync("Id", r.Id);
                        newRestaurant.Add(new Restaurant 
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Locations = locations,
                            Reviews = reviews
                        });
                    }
                } 
            }
            return newRestaurant;
        }
        public async Task<List<Reviews>> DisplayReviewAsync(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = await repoRev.DisplayReviewsAsync(whereIt, equalsTo);
            return reviews;
        }

        public void DeleteLocation(string equalsTo)
        {
            repoLoc.DeleteRestLocation(equalsTo);
        }

        public List<Location> DisplayAllRestLocation()
        {
            List<Location>? location = repoLoc.DisplayAllRestLocation();
            return location;
        }

        public async Task<List<Location>> DisplayAllRestLocationAsync()
        {
            List<Location>? location = await repoLoc.DisplayAllRestLocationAsync();
            return location;
        }
    }
}