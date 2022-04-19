using RestaurantRateAndReview;

CreateUser newUser = new CreateUser();

newUser.FirstName= Console.ReadLine();
newUser.LastName= Console.ReadLine();
newUser.MidName= Console.ReadLine();
newUser.UserName= Console.ReadLine();
newUser.UserPassword= Console.ReadLine();
newUser.UserEmail= Console.ReadLine();

Console.WriteLine($"{newUser.FirstName} {newUser.MidName} {newUser.LastName}");
Console.WriteLine($"{newUser.UserName} {newUser.UserPassword} {newUser.UserEmail}");
