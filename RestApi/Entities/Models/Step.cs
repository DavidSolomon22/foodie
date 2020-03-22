using System;

namespace Entities.Models
{
    public class Step
    {
        public Guid Id {get; set;}
        public Guid RecipeId {get; set;}
        public string Instruction {get; set;}

        public Recipe Recipe {get; set;}
    }
}