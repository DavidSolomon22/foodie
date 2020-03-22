using System;

namespace Entities.Models
{
    public class Ingredient
    {
        public Guid Id {get; set;}
        public Guid RecipeId {get; set;}
        public string Name {get; set;}
        public string Unit {get; set;}
        public float Quantity {get; set;}

    }
}