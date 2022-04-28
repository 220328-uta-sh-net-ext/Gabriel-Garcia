using UserML;

namespace UserBL
{
    public interface IUserLogic
    {
        User AddUser(User u);
        string SearchUser(string name,string pass);
        void SearchUserName(string name);
        void SearchUserID(string id);
        void SearchUser();
        bool SearchUser(string name);
    }
    interface IUserSearch
    {
        List<User> SearchAllUser();
    }
}
