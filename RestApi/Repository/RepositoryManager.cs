using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _userRepository;
        private IRecipeRepository _recipeRepository;
        private IDietRepository _dietRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public IRecipeRepository Recipe
        {
            get
            {
                if (_recipeRepository == null)
                    _recipeRepository = new RecipeRepository(_repositoryContext);

                return _recipeRepository;
            }
        }
        public IDietRepository Diet
        {
            get
            {
                if (_dietRepository == null)
                    _dietRepository = new DietRepository(_repositoryContext);

                return _dietRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
