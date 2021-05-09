using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.UserName)
            .ToList();

        public User GetUser(int Id, bool trackChanges) => FindByCondition(c => c.UserId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<User> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.UserId), trackChanges)
          .ToList();

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user)
        {
            Delete(user);
        }

    }
}
