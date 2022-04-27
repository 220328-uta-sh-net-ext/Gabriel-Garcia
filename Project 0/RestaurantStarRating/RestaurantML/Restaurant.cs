namespace RestaurantML
{
    public class Restaurant
    {
        public string sName { get; set; }
        public string sID { get; set; }
        public string sContry { get; set; }
        public string sState { get; set; }
        public string sZipcode { get; set; }
        public string sType { get; set; }
        public string Review { get; set; }
        public string NumberOfReview { get; set; }

        public Restaurant()
        {
            sName = "";
            sID = "";
            sContry = "";
            sState = "";
            sZipcode = "";
            sType = "";
            Review = "";
            NumberOfReview = "";
        }
        public override string ToString()
        {
            return $"Name:{Name}\nID:{ID}\nAddress:{Address}\nZippcode:{Zipcode}\nReview:{Review}\nNumberOfReview:{NumberOfReview}";
        }

    }
}