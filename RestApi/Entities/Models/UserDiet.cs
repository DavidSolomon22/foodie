using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("UserDiets")]
    public class UserDiet
    {
        public Guid Id {get; set;}
        [ForeignKey("User")]
        public string UserId {get; set;}
        [ForeignKey("Diet")]
        public Guid DietId {get; set;}

        public Diet Diet {set; get;}
        public User User {set; get;}
    }
}