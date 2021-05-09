using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetUser(int Id, bool trackChanges);
        IEnumerable<User> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateUser(User user);

        void DeleteUser(User user);
    }
}
