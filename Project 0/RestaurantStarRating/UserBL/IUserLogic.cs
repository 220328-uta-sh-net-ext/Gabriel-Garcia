using UserML;

namespace UserBL
{
    public interface IUserLogic
    {
        User AddUser(User u);
        List<User> SearchUser(string name,string pass);
    }
    interface IUserSearch
    {
        List<User> SearchAllUser();
    }
}
