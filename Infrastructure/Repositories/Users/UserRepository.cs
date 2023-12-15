using Domain;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Users;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                _realDatabase.Users.Add(userToRegister);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            try
            {
                List<User> allUsersFromDatabase = _realDatabase.Users.ToList();
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
