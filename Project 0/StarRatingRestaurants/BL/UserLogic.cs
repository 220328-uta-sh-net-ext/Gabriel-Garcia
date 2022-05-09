using DL;
using Models;

namespace BL
{
    public class UserLogic : IUserLogic
    {
        readonly IRepositoryU repo;
        readonly IRepositoryRev repoRev;

        public UserLogic(IRepositoryU repo, IRepositoryRev repoRev)
        {
            this.repo = repo;
            this.repoRev = repoRev;
        }
        public Reviews AddReviews(Reviews rev)
        {
            return repoRev.AddReviews(rev);
        }

        public User AddUser(User u)
        {
            return repo.AddUser(u);
        }
        public void DeleteUser(string user, string id)
        {
            repo.DeleteUser(user);
            repoRev.DeleteReviews("ReviewerId", id);
        }

        public List<User> SearchUser(string name, string equalsTo)
        {
            List<User>? user = repo.DisplayUser(name, equalsTo);
            return user;
        }
    }
}
