using Models;
namespace API.Repository
{
    public interface IJWTManagerRepository
    {
        Token Authenticate(User user);
    }
}
