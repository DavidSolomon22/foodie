using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DailyDiet
    {
        public Guid Id {get; set;}
        public Guid DietId {get; set;}
        public DateTime Day {get; set;}

        public ICollection<Meal> Meals {get; set;}
    }
}