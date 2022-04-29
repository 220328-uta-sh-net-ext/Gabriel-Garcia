using RestaurantDL;
using RestaurantML;

namespace RestaurantBL
{
    public class RestaurantLogic : IRestaurantLogic
    {
        IRestaurantRepo repo = new RestaurantRepo();
        public Restaurant AddRestaurant(Restaurant r)
        {
            return repo.AddRestaurant(r);
        }
        public List<Restaurant> SearchRestaurant(string name, string id)
        {
            var vRestaurant = repo.GetAllRestaurants();
            var vfilteredRestaurant = vRestaurant.Where(r => r.Name.Contains(name)).ToList();
            return vfilteredRestaurant;
        }
        public void SearchRestaurant()
        {
            var vRest = repo.GetAllRestaurants();
            foreach (var r in vRest)
            {
                Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                foreach(var r2 in r.Locations)
                {
                    Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                }
                Console.WriteLine("\n+--------------------+");
            }
        }
        public void SearchRestaurant(string sType,string sContry,string sState, string sZip, string name, string id)
        {
            var vRest = repo.GetAllRestaurants();
            foreach (var r in vRest)
            {
                //Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                foreach (var r2 in r.Locations)
                {
                    if (r.Name == name && r.ID == id)
                    {
                        Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                        Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                        break;
                    }
                    else if (r.ID == id && (name == ""))
                    {
                        Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                        Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                    }
                    else if (r.Name == name && (id == ""))
                    {
                        Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                        Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                    }
                    else if ((name =="") &&( r.Type == sType || ( r2.Contry == sContry || r2.State == sState || r2.Zipcode == sZip)))
                    {
                        Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                        Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                    }
                }
            }
        }
        public void PrintRateRestaurant(string n, string i)
        {
            var vRest = repo.GetAllRestaurants();
            foreach (var r in vRest)
            {
                foreach (var r2 in r.Locations)
                {
                    if (r.Name == n && r.ID == i)
                    {
                        Console.Write($"\nRestaurant: {r.Name}\n\tID:{r.ID}\n\tRating:{r.Review} Stars, {r.NumberOfReview} Reviews\n\tType:{r.Type}\n\tLocation:");
                        Console.Write($" {r2.Contry}, {r2.State}, {r2.Zipcode}\n");
                    }
                }
            }
            Console.WriteLine("\n+--------------------+");
        }

    }
}