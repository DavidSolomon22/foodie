using System;

namespace Entities.Models
{
    public class DailyMeal
    {
        public Guid Id {get; set;}
        public Guid RecipeId {get; set;}
        public DateTime Day {get; set;}
    }
}