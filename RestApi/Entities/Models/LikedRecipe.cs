using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("LikedRecipes")]
    public class LikedRecipe
    {
        public Guid Id {get; set;}
        [ForeignKey("User")]
        public string UserId {get; set;}
        [ForeignKey("Recipe")]
        public Guid RecipeId {get; set;}

        public User User {set; get;}
        public Recipe Recipe {set; get;}

    }
}