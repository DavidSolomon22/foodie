using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public User User {get; set;}
        [JsonIgnore]
        public Recipe Recipe {set;get;}

        public Rate()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}