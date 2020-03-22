using System;

namespace Entities.Models
{
    public class Meal
    {
        public Guid Id {get; set;}
        public Guid RecipeId {get; set;}
        public Guid DailyDietId {get; set;}
        public string Type {get; set;}
    }
}