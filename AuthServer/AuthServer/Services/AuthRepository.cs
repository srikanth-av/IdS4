using AuthServer.Data;
using AuthServer.Model;
using System.Linq;

namespace AuthServer.Service
{
    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext _dbContext;

        public AuthRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(long id)
        {
            return _dbContext.User.Where(x => x.Id == id).FirstOrDefault();    
        }

        public User GetUserByName(string name)
        {
            return _dbContext.User.Where(x => x.Email == name).FirstOrDefault();
        }

        public bool ValidatePassword(string username, string plainPassword)
        {
            var user = _dbContext.User.Where(x => x.Email == username && x.Password == plainPassword).FirstOrDefault();
            return user != null;
        }
    }
}
