using System.Threading.Tasks;
using Entities.DataTransferObjects;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<bool> IsEmailConfirmed(string email);
    }
}