using MainBL;
using MainDL;
using MainML;

namespace MainBL
{
    public class RestaurantLogic : IRestaurantLogic
    {
        readonly IRepositoryR repo;
        public RestaurantLogic(IRepositoryR repo)
        {
            this.repo = repo;
        }
        public Restaurant AddRestaurant(Restaurant r)
        {
            return repo.AddRestaurant(r);
        }

        public List<Restaurant> DisplayRestaurant()
        {
            List<Restaurant> rest = repo.GetAllRestaurants();
            return rest;
        }

        public void RateRestaurant(string sid, int id)
        {
            repo.AddReview(sid,id);
        }

        public List<Restaurant> SearchRestaurant(string name, string c)
        {
            List<Restaurant>? user = repo.GetAllRestaurants();

            var filerUser = user;
            if (c == "name")
                filerUser = user.Where(x => x.Name.Contains(name)).ToList();
            else if (c == "country")
                filerUser = user.Where(x => x.Country.Contains(name)).ToList();
            else if (c == "state")
                filerUser = user.Where(x => x.State.Contains(name)).ToList();
            else if (c == "zipcode")
                filerUser = user.Where(x => x.Zipcode.Contains(name)).ToList();
            else if (c == "TypeOf")
                filerUser = user.Where(x => x.TypeOf.Contains(name)).ToList();
            else if(c == "id")
                filerUser = user.Where(x => x.ID.Contains(name)).ToList();

            return filerUser;
        }
    }
}