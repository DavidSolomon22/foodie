using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class DietForUpdateDto
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public ICollection<DailyDiet> DailyDiets {get; set;}

    }
}