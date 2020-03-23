using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{ 
    [Table("Diets")]
    public class Diet
    {
        public Guid Id {get; set;}
        [ForeignKey("User")]
        public string CreatorId {get; set;}
        public DateTime DateCreated {get; set;}

        public ICollection<DailyDiet> DailyDiets {get; set;}
        public ICollection<UserDiet> UserDiets {get; set;}
        public User User {get; set;}

    }
}