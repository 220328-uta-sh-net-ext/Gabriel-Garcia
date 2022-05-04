namespace Models
{
    public interface IRestaurantModel
    {
        string Name { get; set; }
        string Id { get; set; }
    }
    public interface IRestLocationModel
    {
        string Id { get; set; }
        string Country { get; set; }
        string State { get; set; }
        string City { get; set; }
        string Zipcode { get; set; }
    }
    public interface IRestReviewsModel
    {
        string Id { get; set; }
        string ReviewerId { get; set; }
        int Rate { get; set; }
        string Review { get; set; }
    }
    public interface IUserModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string ReviewerId { get; set; }
    }
}
