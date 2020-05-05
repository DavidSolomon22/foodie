using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("DailyDiets")]
    public class DailyDiet
    {
        public Guid Id {get; set;}
        [ForeignKey("Diet")]
        public Guid DietId {get; set;}
        public string Day {get; set;}

        public ICollection<Meal> Meals {get; set;}
        [JsonIgnore]
        public Diet Diet {set; get;}
    }
}