using UserML;

namespace UserBL
{
    public interface IUserLogic
    {
        User AddUser(User u);
        string SearchUser(string name,string pass);
        List<User> SearchUser(string name);
    }
    interface IUserSearch
    {
        List<User> SearchAllUser();
    }
}
