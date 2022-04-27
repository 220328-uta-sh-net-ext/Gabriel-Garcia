using UserDL;
using UserML;

namespace UserBL
{
    public class UserLogic : IUserLogic
    {
        IUserRepo repo = new UserRepo();
        public User AddUser(User u)
        {
            //setup user id
            //check if user exist
            //var vUser = repo.GetAllUser();
            return repo.AddUser(u);
        }

        public List<User> SearchUser(string name, string pass)
        {
            var vUser = repo.GetAllUser();
            var vFilteredUser = vUser.Where(x => x.UserName.Contains(name)).ToList();
            return vFilteredUser;
        }
    }
}