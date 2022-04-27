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
        public string sReview { get; set; }
        public string NumberOfReview { get; set; }

        public Restaurant()
        {
            sName = "";
            sID = "";
            sContry = "";
            sState = "";
            sZipcode = "";
            sType = "";
            sReview = "";
            NumberOfReview = "";
        }
        public override string ToString()
        {
            return $"Name:{sName}\nID:{sID}\nContry:{sContry}\nState:{sState}\nZipcode:{sZipcode}\nType:{sType}\nReview:{sReview}";
        }

    }
}