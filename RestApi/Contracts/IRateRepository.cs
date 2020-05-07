using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IRateRepository
    {
        void CreateRate(Rate rate);
        Task<IEnumerable<Rate>> GetAllRatesForRecipeAsync(Guid recipeId, bool trackChanges);
        void DeleteRate(Rate rate);
    }
}
