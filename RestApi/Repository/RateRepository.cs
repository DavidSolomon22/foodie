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
    public class RateRepository : RepositoryBase<Rate>, IRateRepository
    {
        public RateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateRate(Rate rate) => Create(rate);

        public async Task<IEnumerable<Rate>> GetAllRatesForRecipeAsync(Guid recipeId, bool trackChanges) =>
            await FindByCondition(r => r.RecipeId.Equals(recipeId), trackChanges)
                .OrderBy(r => r.DateCreated)
                .ToListAsync();


        public void DeleteRate(Rate rate) => Delete(rate);
    }
}