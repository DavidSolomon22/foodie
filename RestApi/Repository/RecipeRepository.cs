using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Entities.RequestFeatures;

namespace Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateRecipe(Recipe recipe) => Create(recipe);

        public async Task<PagedList<Recipe>> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges)
        {
            var recipes = await FindAll(trackChanges)
                .FilterRecipes(recipeParameters.Cuisine, recipeParameters.Category, recipeParameters.ComplexityLevel)
                .Search(recipeParameters.SearchTerm)
                .OrderBy(r => r.Name)
                .ToListAsync();

            return PagedList<Recipe>
                .ToPagedList(recipes, recipeParameters.PageNumber, recipeParameters.PageSize);
        }

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
