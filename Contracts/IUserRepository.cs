using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IUserRepository
    {
        PagedList<User> GetAllUsers(UserParameters userParameters, bool trackChanges);
        User GetUser(int userId, bool trackChanges);

        void DeleteUser(User user);
        void CreateUser(User user);
    }
}