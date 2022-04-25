namespace RestaurantML
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Review { get; set; }
        public string NumberOfReview { get; set; }

        public Restaurant()
        {
            Name = "";
            ID = "";
            Address = "";
            Zipcode = "";
            Review = "";
            NumberOfReview = "";
        }
        public override string ToString()
        {
            return $"Name:{Name}\nID:{ID}\nAddress:{Address}\nZippcode:{Zipcode}\nReview:{Review}\nNumberOfReview:{NumberOfReview}";
        }

    }
}