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
                if (v.Password == pass && v.ID.Contains("000000000"))
                { result = "Admin"; break; }
                if (v.Password == pass && !v.ID.Contains("000000000"))
                { result = "User"; break; }
                else
                    { result = "NoUser";}
            }
           return result;
        }
        public void SearchUser()
        {
            var vUser = repo.GetAllUser();
            foreach (var u in vUser)
            {
                Console.WriteLine($"User: {u.UserName}\n\tFrist Name: {u.FirstName}\n\tLast Name: {u.LastName}\n\tID: {u.ID}\n");
            }
        }

        public bool SearchUser(string name)
        {
            var vUser = repo.GetAllUser();
            var vFilteredUser = vUser.Where(x => x.UserName.Contains(name)).ToList();
            foreach (var u in vFilteredUser)
            {
                if(u.UserName == name)
                    { return true; }
            }
            return false;
        }

        public void SearchUserID(string id)
        {
            var vUser = repo.GetAllUser();
            var vFilteredUser = vUser.Where(x => x.ID.Contains(id)).ToList();
            foreach (var u in vFilteredUser)
            {
                Console.WriteLine($"{u.FirstName} {u.LastName} {u.UserName} {u.ID}");
            }
        }

        public void SearchUserName(string name)
        {
            var vUser = repo.GetAllUser();
            var vFilteredUser = vUser.Where(x => x.UserName.Contains(name)).ToList();
            foreach(var u in vFilteredUser)
            {
                Console.WriteLine($"{u.FirstName} {u.LastName} {u.UserName} {u.ID}");
            }
        }
    }
}