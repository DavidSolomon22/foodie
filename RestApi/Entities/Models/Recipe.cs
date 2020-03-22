using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Recipe
    {
        public Guid Id {get; set;}
        [ForeignKey("User")]
        public string CreatorId {get; set;}
        public string Name {get; set;}
        public string Category {get; set;}
        public string Cuisine {get; set;}
        public DateTime DateCreated {get; set;}
        public string PhotoPath {get; set;}
        public int ComplexityLevel {get; set;}
        public int EstimatedTime {get; set;}

        public User User {get; set;}

        public ICollection<Rate> Rates {get; set;}
        public ICollection<DailyMeal> DailyMeals {get; set;}
        public ICollection<LikedRecipe> LikedRecipes {get; set;}
        public ICollection<Step> Steps {get; set;}
        public ICollection<Meal> Meals {get; set;}
        public ICollection<Ingredient> Ingredients {get; set;}
    }
}