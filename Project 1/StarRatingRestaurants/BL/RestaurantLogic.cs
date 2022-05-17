using DL;
using Models;

namespace BL
{
    public class RestaurantLogic : IRestaurantLogic
    {
        readonly IRepositoryR repo;
        readonly IRepositoryRev repoRev;
        readonly IRepositoryLoc repoLoc;

        static  Restaurant rest = new();
        static  Reviews rev = new();
        static  List<Reviews> rev2 = new();
        static List<Restaurant> rest2 = new();
        public RestaurantLogic(IRepositoryR repo, IRepositoryRev repoRev, IRepositoryLoc repoLoc)
        {
            this.repo = repo;
            this.repoRev = repoRev;
            this.repoLoc = repoLoc; 
        }
        /// <summary>
        /// This add a Restaurant and it's location
        /// </summary>
        /// <param name="r"></param>
        /// <param name="l"></param>
        public void AddRestaurant(Restaurant r, Location l)
        {
            repo.AddRestaurant(r);
            repoLoc.AddRestLocation(l);            
        }
        /// <summary>
        /// this delete's the Restaurant starting from it's
        /// Locaiton then it's Review's and finaly the Restaurant
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRestaurant(string id)
        {
            repoLoc.DeleteRestLocation(id);
            repoRev.DeleteReviews("Id", id);
            repo.DeleteRestaurant(id);
        }
        /// <summary>
        /// display restaruant by geting it's id or it's name
        /// then it get it's id as it is the primary key
        /// then it is used in looking up the location and review
        /// </summary>
        /// <param name="whereIt"></param>
        /// <param name="equalsTo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// display all restaruant and as well displaying location and review
        /// then it get it's id as it is the primary key
        /// then it is used in looking up the location and review
        /// </summary>
        /// <returns></returns>
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
        //----------------Async-----------------------

        /// <summary>
        /// this are not done but are th async intemp
        /// of what is going on above
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public async Task<Restaurant> AddRestaurantAsync(Restaurant r)
        {
            return await repo.AddRestaurantAsync(r);
        }

        public async Task<List<Restaurant>> SearchRestaurantAsync(string whereIt, string equalsTo)
        {
            List<Restaurant>? restaurants = await repo.SearchRestaurantsAsync(whereIt, equalsTo);
            return restaurants;
        }

        //public async Task<List<Location>> SearchRestLocationAsync(string whereIt, string equalsTo)
        //{
        //    List<Location>? location = await repoLoc.SearchRestLocationAsync(whereIt, equalsTo);
        //    return location;
        //}

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

        public string GetRestaurant(string id)
        {
            int rate = 0;
            int rCount = 0;
            string name = "";
            rest2 = repo.SearchRestaurants("Id", id);
            foreach (var i in rest2)
            {
                name = i.Name;
            }

            rev2 = repoRev.DisplayReviews("Id", id);
            foreach(var i in rev2)
            {
                rate += i.Rate;
                rCount++;
            }
            float total = rate / (rCount * 5.0f);
            if (total > 0.9)
            { total = 5; }
            else if (total > 0.8)
            { total = 4; }
            else if (total > 0.6)
            { total = 3; }
            else if (total > 0.4)
            { total = 2; }
            else if (total > 0.2)
            { total = 1; }
            else total = 0;

                                return $"Restaurant: {name} Rate: {total} ";
        }
        //public async Task<List<Reviews>> DisplayReviewAsync(string whereIt, string equalsTo)
        //{
        //    List<Reviews>? reviews = await repoRev.DisplayReviewsAsync(whereIt, equalsTo);
        //    return reviews;
        //}
        // public async Task<List<Location>> DisplayAllRestLocationAsync()
        // {
        //     List<Location>? location = await repoLoc.DisplayAllRestLocationAsync();
        //     return location;
        // }
    }
}