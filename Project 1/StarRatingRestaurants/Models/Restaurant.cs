namespace Models
{
    public class Restaurant : IRestaurantModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        ~Restaurant() { }
        public Restaurant()
        {
            Name = "";
            Id = "";
        }
    }
}