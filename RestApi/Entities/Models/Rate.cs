using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Rates")]
    public class Rate
    {
        public Guid Id {get; set;}
        [ForeignKey("Recipe")]
        public Guid RecipeId {get; set;}
        [ForeignKey("User")]
        public string AuthorId {get;set;}
        public string Comment {get; set;}
        public int Value {get; set;}
        public DateTime DateCreated {get; set;}

        public User User {get; set;}
        public Recipe Recipe {set;get;}
    }
}