using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public ICollection<LikedRecipe> LikedRecipes {get; set;}
        public ICollection<UserDiet> UserDiets {get; set;}

        public ICollection<Rate> Rates {get; set;}
        public Recipe Recipe {get; set;} 
        public Diet Diet {get; set;}
    }
}