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
        private IRateRepository _rateRepository;
        private ILikedRecipeRepository _likedRecipeRepository;

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
        public IRateRepository Rate
        {
            get
            {
                if (_rateRepository == null)
                    _rateRepository = new RateRepository(_repositoryContext);

                return _rateRepository;
            }
        }
        public ILikedRecipeRepository LikedRecipe
        {
            get
            {
                if (_likedRecipeRepository == null)
                    _likedRecipeRepository = new LikedRecipeRepository(_repositoryContext);

                return _likedRecipeRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
