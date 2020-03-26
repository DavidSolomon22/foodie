using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(u => u.Email)
            .ToListAsync();

        public async Task<User> GetUserAsync(string userId, bool trackChanges) => 
            await FindByCondition(u => u.Id.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<string> ids, bool trackChanges) =>
            await FindByCondition(u => ids.Contains(u.Id), trackChanges)
            .ToListAsync();

        public void DeleteUser(User user) => Delete(user);
    }
}
