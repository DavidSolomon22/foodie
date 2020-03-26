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
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateRecipe(Recipe recipe) => Create(recipe);

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(r => r.Name)
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .ToListAsync();

        public async Task<Recipe> GetRecipeAsync(Guid recipeId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(recipeId), trackChanges)
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Recipe>> GetRecipesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(r => ids.Contains(r.Id), trackChanges)
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .ToListAsync();

        public void DeleteRecipe(Recipe recipe) => Delete(recipe);
    }
}
