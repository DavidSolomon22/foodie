using System;

namespace Entities.Models
{
    public class LikedRecipe
    {
        public Guid Id {get; set;}
        public string UserId {get; set;}
        public Guid RecipeId {get; set;}
    }
}