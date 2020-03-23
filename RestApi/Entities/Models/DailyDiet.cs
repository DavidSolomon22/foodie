using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("DailyDiets")]
    public class DailyDiet
    {
        public Guid Id {get; set;}
        [ForeignKey("Diet")]
        public Guid DietId {get; set;}
        public DateTime Day {get; set;}

        public ICollection<Meal> Meals {get; set;}
        public Diet Diet {set; get;}
    }
}