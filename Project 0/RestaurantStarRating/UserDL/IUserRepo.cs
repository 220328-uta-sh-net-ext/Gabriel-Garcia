using System.Collections.Generic;
using UserML;

namespace UserDL
{
    public interface IUserRepo
    {
        User AddUser(User rest);
        List<User> GetAllUser();
    }
}
