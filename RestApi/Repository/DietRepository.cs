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
        public DietRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDiet(Diet diet) => Create(diet);

        public async Task<IEnumerable<Diet>> GetAllDietAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(d => d.Name)
            .Include(d => d.DailyDiets)
                .ThenInclude(d => d.Meals)
            .ToListAsync();

        public async Task<Diet> GetDietAsync(Guid dietId, bool trackChanges) =>
            await FindByCondition(d => d.Id.Equals(dietId), trackChanges)
            .Include(d => d.DailyDiets)
                .ThenInclude(d => d.Meals)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Diet>> GetDietsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(d => ids.Contains(d.Id), trackChanges)
            .Include(d => d.DailyDiets)
                .ThenInclude(d => d.Meals)
            .ToListAsync();

        public void DeleteDiet(Diet diet) => Delete(diet);
    }
}