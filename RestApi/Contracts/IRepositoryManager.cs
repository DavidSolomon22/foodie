using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IRecipeRepository Recipe { get; }
        IDietRepository Diet { get; }
        Task SaveAsync();
    }
}
