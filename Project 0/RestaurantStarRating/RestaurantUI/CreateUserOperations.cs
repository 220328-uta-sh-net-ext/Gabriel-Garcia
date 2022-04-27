using UserDL;
using UserML;

namespace RestaurantUI
{
    internal class CreateUserOperations
    {
        static UserRepo Repo = new UserRepo();
        public static void GetAllUser()
        {
            var vUser = Repo.GetAllUser();
            foreach(var u in vUser)
            {
                Console.WriteLine(u.ToString());
                Console.WriteLine("-------------------");
            }
        }
    }
}
