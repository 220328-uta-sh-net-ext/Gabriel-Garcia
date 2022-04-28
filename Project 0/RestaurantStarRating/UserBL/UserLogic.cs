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

        public string SearchUser(string name, string pass)
        {
            var vUser = repo.GetAllUser();
            string result = "";
            var vFilteredUser = vUser.Where(x => x.UserName.Contains(name)).ToList();
           foreach(var v in vFilteredUser)
            {
                if (v.Password.Contains(pass) && v.ID.Contains("000000000"))
                { result = "Admin"; break; }
                if (v.Password.Contains(pass) && !v.ID.Contains("000000000"))
                { result = "User"; break; }
                else
                    { result = "NoUser";}
            }
           return result;
        }

        public List<User> SearchUser(string name)
        {
            var vUser = repo.GetAllUser();
            var vFilteredUser = vUser.Where(x => x.UserName.Contains(name)).ToList();
            return vFilteredUser;
        }
    }
}