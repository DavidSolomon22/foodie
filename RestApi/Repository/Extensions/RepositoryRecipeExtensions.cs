using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Extensions
{
    public static class RepositoryRecipeExtensions
    {
        public static IQueryable<Recipe> FilterRecipes(this IQueryable<Recipe> recipes, 
            ICollection<string> Cuisines, ICollection<string> Categories, int ComplexityLevel) =>
            recipes
                .Where(r => Cuisines == null ? true : Cuisines.Contains(r.Cuisine))
                .Where(r => Categories == null ? true : Categories.Contains(r.Category))
                .Where(r => ComplexityLevel == 0 ? true : r.ComplexityLevel == ComplexityLevel);

        public static IQueryable<Recipe> Search(this IQueryable<Recipe> recipes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return recipes;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return recipes.Where(r => r.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}