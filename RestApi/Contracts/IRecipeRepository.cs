using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IRecipeRepository
    {
        void CreateRecipe(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool trackChanges);
        Task<Recipe> GetRecipeAsync(Guid recipeId, bool trackChanges);
        Task<IEnumerable<Recipe>> GetRecipesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteRecipe(Recipe recipe);
    }
}
