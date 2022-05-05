namespace MainML
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string TypeOf { get; set; }
        public int Review { get; set; }
        public int NReview { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        ~Restaurant() { }
        public Restaurant()
        {
            Name = "";
            ID = "";
            TypeOf = "";
            Review = 0;
            NReview = 0;
            Country = "";
            State = "";
            Zipcode = "";
        }
        public override string ToString()
        {
            float Temp = 0.0f;
            if (NReview != 0)
            {
                Temp = Review / (NReview * 5.0f);
                if (Temp <= 0.2f)
                {
                    return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {1} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
                }
                else if (Temp <= 0.4f)
                {
                    return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {2} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
                }
                else if (Temp <= 0.6f)
                {
                    return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {3} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
                }
                else if (Temp <= 0.8f)
                {
                    return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {4} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
                }
                else
                {
                    return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {5} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
                }
            }
            return $"\nRestaurant: {Name}\tID:{ID}\n\nReview({NReview}): {Review} Stars\tType:{TypeOf}\n\tLocation: {Country} {State} {Zipcode}\n";
        
        }
    }
}