using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("DailyMeals")]
    public class DailyMeal
    {
        public Guid Id {get; set;}
        [ForeignKey("Recipe")]
        public Guid RecipeId {get; set;}
        public DateTime Day {get; set;}

        public Recipe Recipe {set; get;}
    }
}