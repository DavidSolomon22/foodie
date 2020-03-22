using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserDiet
    {
        public Guid Id {get; set;}
        [ForeignKey("User")]
        public string UserId {get; set;}
        public Guid DietId {get; set;}
    }
}