using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Steps")]
    public class Step
    {
        public Guid Id {get; set;}
        [ForeignKey("Recipe")]
        public Guid RecipeId {get; set;}
        public string Instruction {get; set;}

        public Recipe Recipe {get; set;}
    }
}