using DL;
using Models;

namespace BL
{
    public class UserLogic : IUserLogic, IReviewLogic
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

        public List<User> DisplayAllUser()
        {
            List<User>? user = repo.DisplayAllUser();
            return user;
        }

        public List<Reviews> DisplayReview(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = repoRev.DisplayReviews(whereIt, equalsTo);
            return reviews;
        }

        public List<User> SearchUser(string name, string equalsTo)
        {
            List<User>? user = repo.SearchUser(name, equalsTo);
            return user;
        }
    }
}
