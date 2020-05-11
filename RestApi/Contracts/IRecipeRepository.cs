using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IRecipeRepository
    {
        void CreateRecipe(Recipe recipe);
        Task<PagedList<Recipe>> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges);
        Task<PagedList<Recipe>> GetRecipesForUserAsync(string userId, RecipeParameters recipeParameters, bool trackChanges);
        Task<Recipe> GetRecipeAsync(Guid recipeId, bool trackChanges);
        Task<IEnumerable<Recipe>> GetRecipesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteRecipe(Recipe recipe);
    }
}
