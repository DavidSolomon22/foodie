using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Extensions
{
    public static class RepositoryRecipeExtensions
    {
        public static IQueryable<Recipe> FilterRecipes(this IQueryable<Recipe> recipes, ICollection<string> Cuisine) =>
            recipes.Where(r => Cuisine == null ? true : Cuisine.Contains(r.Cuisine));

        public static IQueryable<Recipe> Search(this IQueryable<Recipe> recipes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return recipes;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return recipes.Where(r => r.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}