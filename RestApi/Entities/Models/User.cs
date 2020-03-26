using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<LikedRecipe> LikedRecipes {get; set;}
        public ICollection<UserDiet> UserDiets {get; set;}

        public ICollection<Rate> Rates {get; set;}
        public ICollection<Recipe> Recipes {get; set;} 
        public Diet Diet {get; set;}
    }
}
