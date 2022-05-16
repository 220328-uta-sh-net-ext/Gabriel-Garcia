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
        public void DeleteReview(string whereIt, string equalsTo, string whereItU, string equalsToU)
        {
            repoRev.DeleteReviews(whereIt, equalsTo, whereItU, equalsToU);
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
        public string LogingIn(string user, string pass)
        {
            List<User>? getUser = repo.SearchUser("UserName", user);
            if (getUser.Count > 0 && getUser.Count == 1)
            {
                foreach (var u in getUser)
                {
                    if (user == "Admin" && pass == u.Password)
                    { return "AdminMenu"; }
                    else if (pass == u.Password)
                    { return "UserMenu"; }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry! Invalid UserName or Password.\n"); 
                        return "LoginUser";
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry! Invalid User or Password.\n");
            }
            return "LoginUser";
        }
        public List<User> SearchUser(string whereIt, string equalsTo)
        {
            List<User>? user = repo.SearchUser(whereIt, equalsTo);
            return user;
        }
        //--------------------------Async-------------------------
        public async Task<List<Reviews>> DisplayReviewAsync(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = await repoRev.DisplayReviewsAsync(whereIt, equalsTo);
            return reviews;
        }

        public async Task<User> AddUserAsync(User u)
        {
            return await repo.AddUserAsync(u);
        }

        public async Task<Reviews> AddReviewsAsync(Reviews rev)
        {
            return await repoRev.AddReviewsAsync(rev);
        }

        public async Task<List<User>> SearchUserAsync(string whereIt, string equalsTo)
        {
            List<User>? user = await repo.SearchUserAsync(whereIt, equalsTo);
            return user; ;
        }

        public async Task<List<User>> DisplayAllUserAsync()
        {
            List<User>? user = await repo.DisplayAllUserAsync();
            return user;
        }
    }
}
