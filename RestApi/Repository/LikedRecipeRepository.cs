using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LikedRecipeRepository : RepositoryBase<LikedRecipe>, ILikedRecipeRepository
    {
        public LikedRecipeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateLikedRecipe(LikedRecipe likedRecipe) => Create(likedRecipe);

        public async Task<LikedRecipe> GetLikedRecipeAsync(Guid likedRecipeId, bool trackChanges) =>
            await FindByCondition(l => l.LikedRecipeId.Equals(likedRecipeId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<LikedRecipe>> GetLikedRecipesForUserAsync(string userId, bool trackChanges) =>
            await FindByCondition(l => l.UserId.Equals(userId), trackChanges)
            .ToListAsync();

        public void DeleteLikedRecipe(LikedRecipe likedRecipe) => Delete(likedRecipe);
    }
}
