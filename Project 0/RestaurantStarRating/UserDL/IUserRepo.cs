using System.Collections.Generic;
using UserML;

namespace UserDL
{
    internal interface IUserRepo
    {
        User AddUser(User rest);
        List<User> GetAllRestaurants();
    }
}
