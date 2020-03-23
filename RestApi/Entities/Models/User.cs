using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public ICollection<LikedRecipe> LikedRecipes {get; set;}
        public ICollection<UserDiet> UserDiets {get; set;}

        public ICollection<Rate> Rates {get; set;}
        public Recipe Recipe {get; set;} 
        public Diet Diet {get; set;}
    }
}