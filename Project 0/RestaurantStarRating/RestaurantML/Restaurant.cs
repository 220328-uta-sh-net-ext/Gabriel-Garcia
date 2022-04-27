namespace RestaurantML
{
    public class Restaurant
    {
        public string sName { get; set; }
        public string sID { get; set; }
        public string sType { get; set; }
        public string sReview { get; set; }
        public string NumberOfReview { get; set; }
        private List<Location> _locations;
        public List<Location> Locations
        {
            get => _locations;
            set 
            {
                _locations = value; 
            } 
        } 
        public Restaurant()
        {
            sName = "";
            sID = "";
            sType = "";
            sReview = "";
            NumberOfReview = "";
            _locations = new List<Location>()
            { new Location()};
        }
        public override string ToString()
        {
            return $"Name:{sName}\nID:{sID}\nType:{sType}\nReview:{sReview}";
        }

    }
}