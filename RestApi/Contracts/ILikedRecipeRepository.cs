using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ILikedRecipeRepository
    {
        void CreateLikedRecipe(LikedRecipe likedRecipe);
        Task<IEnumerable<LikedRecipe>> GetLikedRecipesForUserAsync(string userId, bool trackChanges);
        Task<LikedRecipe> GetLikedRecipeAsync(Guid likedRecipeId, bool trackChanges);
        void DeleteLikedRecipe(LikedRecipe likedRecipe);
    }
}
