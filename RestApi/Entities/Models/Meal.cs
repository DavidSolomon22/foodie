using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("Meals")]
    public class Meal
    {
        public Guid Id {get; set;}
        [ForeignKey("Recipe")]
        public Guid RecipeId {get; set;}
        [ForeignKey("DailyDiet")]
        public Guid DailyDietId {get; set;}
        public string Type {get; set;}

        [JsonIgnore]
        public Recipe Recipe {set; get;}
        public DailyDiet DailyDiet {set; get;}

    }
}