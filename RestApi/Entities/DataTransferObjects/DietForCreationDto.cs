using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class DietForCreationDto
    {
        public string CreatorId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public ICollection<DailyDiet> DailyDiets {get; set;}

    }
}