namespace RestaurantML
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Review { get; set; }
        public string NumberOfReview { get; set; }
        private List<Location> _locations;
        public List<Location> Locations
            { get => _locations; set { _locations = value; } }
        public Restaurant()
        {
            Name = "";
            ID = "";
            Type = "";
            Review = "";
            NumberOfReview = "";
            _locations = new List<Location>()
            { new Location()};
        }
        public override string ToString()
        {
            return $"Name:{Name}\nID:{ID}\nType:{Type}\nReview:{Review}";
        }

    }
}