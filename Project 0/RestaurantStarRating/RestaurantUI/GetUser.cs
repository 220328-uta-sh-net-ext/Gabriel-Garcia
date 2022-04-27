using UserDL;
using UserML;

namespace RestaurantUI 
{
    internal class GetUser
    {
        private static UserRepo repository = new UserRepo();
        public static void GetAllUser()
        {
            repository.GetAllUser();
        }
    }
}
