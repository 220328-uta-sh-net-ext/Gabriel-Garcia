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
        /// <summary>
        /// gets user input and store it in a reviews model
        /// and add it to the database
        /// </summary>
        /// <param name="rev"></param>
        /// <returns>Reviews</returns>
        public Reviews AddReviews(Reviews rev)
        {
            return repoRev.AddReviews(rev);
        }
        /// <summary>
        /// gets user input and store it in a user model
        /// and add it to the database
        /// </summary>
        /// <param name="u"></param>
        /// <returns>User</returns>
        public User AddUser(User u)
        {
            return repo.AddUser(u);
        }
        /// <summary>
        /// delete review get the user id and restaurant id
        /// and check if there is a item in the database
        /// if there is no item then it dose nothing 
        /// but if there was anything found then delete it
        /// </summary>
        /// <param name="whereIt"></param>
        /// <param name="equalsTo"></param>
        /// <param name="whereItU"></param>
        /// <param name="equalsToU"></param>
        public void DeleteReview(string whereIt, string equalsTo, string whereItU, string equalsToU)
        {
            repoRev.DeleteReviews(whereIt, equalsTo, whereItU, equalsToU);
        }
        /// <summary>
        /// delete the user and the review to any review done to a restaurant
        /// gets the username and id and use it to find any review this that
        /// bit of data and delete them and the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        public void DeleteUser(string user, string id)
        {
            repo.DeleteUser(user);
            repoRev.DeleteReviews("ReviewerId", id);
        }
        /// <summary>
        /// simply display all users
        /// </summary>
        /// <returns></returns>
        public List<User> DisplayAllUser()
        {
            List<User>? user = repo.DisplayAllUser();
            return user;
        }
        /// <summary>
        /// dose a check if the user exist and return AdminMenu or UserMenu
        /// if we find that the user model have the username and password
        /// correct esle it return junk to be prosset in the ui or api
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string LogingIn(User user)
        {
            List<User>? getUser = repo.SearchUserAdmin("UserName", user.UserName);
            if (getUser.Count > 0)
            {
                foreach (var u in getUser)
                {
                    if (user.UserName == "Admin" && user.Password == u.Password)
                    { return "AdminMenu"; }
                    else if (user.Password == u.Password)
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
        /// <summary>
        /// searches for a user the its colom with it's valuse given
        /// but this one dose not send the admin
        /// </summary>
        /// <param name="whereIt"></param>
        /// <param name="equalsTo"></param>
        /// <returns></returns>
        public List<User> SearchUser(string whereIt, string equalsTo)
        {
            List<User>? user = repo.SearchUser(whereIt, equalsTo);
            return user;
        }
        /// <summary>
        /// searches for a user the its colom with it's valuse given
        /// all and the admin
        /// </summary>
        /// <param name="whereIt"></param>
        /// <param name="equalsTo"></param>
        /// <returns></returns>
        public List<User> SearchUserAll(string whereIt, string equalsTo)
        {
            List<User>? user = repo.SearchUserAdmin(whereIt, equalsTo);
            return user;
        }
        /// <summary>
        /// simply get the review and display it using the vause given
        /// </summary>
        /// <param name="whereIt"></param>
        /// <param name="equalsTo"></param>
        /// <returns></returns>
        public List<Reviews> DisplayReview(string whereIt, string equalsTo)
        {
            List<Reviews>? reviews = repoRev.DisplayReviews(whereIt, equalsTo);
            return reviews;
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
            return user;
        }
        public async Task<string> SearchUserNameAsync(string equalsTo)
        {
            List<User>? user = await repo.SearchUserAsync("UserName", equalsTo);
            if (user.Count > 0)
            {
                string userName = user[0].UserName;
                return userName;
            }
            return "";
        }
        public async Task<string> SearchUserPasswordAsync(string equalsTo)
        {
            List<User>? user = await repo.SearchUserAsync("UserName", equalsTo);
            if (user.Count > 0)
            {
                string userPass = user[0].Password;
                return userPass;
            }
            return "";
        }
        public async Task<List<User>> DisplayAllUserAsync()
        {
            List<User>? user = await repo.DisplayAllUserAsync();
            return user;
        }
    }
}
