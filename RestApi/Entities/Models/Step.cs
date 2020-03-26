using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("Steps")]
    public class Step
    {
        public Guid Id { get; set; }
        [ForeignKey("Recipe")]
        public Guid RecipeId { get; set; }
        public string Instruction { get; set; }

        [JsonIgnore]
        public Recipe Recipe { get; set; }
    }
}
