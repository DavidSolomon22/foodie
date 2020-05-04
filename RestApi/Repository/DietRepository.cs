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
    public class DietRepository : RepositoryBase<Diet>, IDietRepository
    {
        public DietRepository(RepositoryContext RepositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDiet(Diet diet) => Create(diet);

        public async Task<IEnumerable<Diet>> GetAllDietAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(d => r.Name)
            .Include(d => r.DailyDiets)
            .ToListAsync();

        public async Task<Diet> GetDietAsync(Guid dietId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(recipeId), trackChanges)
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Diet>> GetDietsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(r => ids.Contains(r.Id), trackChanges)
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .ToListAsync();

        public void DeleteDiet(Diet diet) => Delete(recipe);
    }
}