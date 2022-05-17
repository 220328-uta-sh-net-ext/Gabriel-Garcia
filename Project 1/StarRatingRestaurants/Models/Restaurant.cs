namespace Models
{
    public class Restaurant : IRestaurantModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        List<Location> _locations;
        List<Reviews> _reviews;
        ~Restaurant() { }
        public List<Location> Locations
        {
            get => _locations;
            set { _locations = value; }
        }
        public List<Reviews> Reviews
        {
            get => _reviews;
            set { _reviews = value; }
        }
        public Restaurant()
        {
            Name = "";
            Id = "";
            _locations = new List<Location>()
            {
                new Location()
            };
            _reviews = new List<Reviews>()
            {
                new Reviews()
            };
        }
    }
}