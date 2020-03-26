using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        public Guid Id { get; set; }
        [ForeignKey("Recipe")]
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float Quantity { get; set; }

        [JsonIgnore]
        public Recipe Recipe { get; set; }
    }
}
