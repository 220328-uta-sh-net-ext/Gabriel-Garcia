namespace Models
{
    public class Restaurant : IRestaurantModel, IRestLocationModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        ~Restaurant() { }
        public Restaurant()
        {
            Name = "";
            Id = "";
            Country = "";
            State = "";
            City = "";
            Zipcode = "";
        }
        public override string ToString()
        {
            return $"\nRestaurant: {Name}\tID:{Id}\n\tLocation: {Country} {State} {City} {Zipcode}\n";
        }
    }
}