using AuthServer.Model;

namespace AuthServer.Service
{
    public interface IAuthRepository
    {
        User GetUserById(long id);
        User GetUserByName(string name);
        bool ValidatePassword(string username, string plainPassword);
    }
}
