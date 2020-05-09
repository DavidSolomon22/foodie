using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class DietDto
    {
        public Guid Id {get; set;}
        public string CreatorId {get; set;}
        public DateTime DateCreated {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}

        public ICollection<DailyDiet> DailyDiets {get; set;}

    }
}