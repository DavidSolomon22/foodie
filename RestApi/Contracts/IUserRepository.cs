using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(string userId, bool trackChanges);
        Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<string> ids, bool trackChanges);
        void DeleteUser(User user);
    }
}
