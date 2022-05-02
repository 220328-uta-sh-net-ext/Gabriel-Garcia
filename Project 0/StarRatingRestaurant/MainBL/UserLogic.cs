using MainML;
using MainDL;

namespace MainBL
{
    public class UserLogic : IUserLogic
    {
        readonly IRepositoryU repo;
        public UserLogic(IRepositoryU repo)
        {
            this.repo = repo;
        }
        public User AddUser(User u)
        {
            return repo.AddUser(u);
        }

        public List<User> DisplayUser()
        {
            List<User>? user = repo.GetAllUser();
            return user;
        }

        public string LogUser(string name, string pass)
        {
            List<User>? user = repo.GetLogUser();
            foreach(var i in user)
            {
                if (name == i.UserName && pass == i.Password)
                    if (i.UserName == "Admin")
                        return "AdminMenu";
                    else
                        return "UserMenu";                 
            }
            return "No";
        }

        public List<User> SearchUser(string name, string c)
        {
            List<User>? user = repo.GetAllUser();
            var filerUser = user;
            if (c == "fname")
                filerUser = user.Where(x => x.FName.Contains(name)).ToList();
            else if (c == "lname")
                filerUser = user.Where(x => x.LName.Contains(name)).ToList();
            else if(c == "uname")
                filerUser = user.Where(x => x.UserName.Contains(name)).ToList();
            return filerUser;
        }
    }
}
