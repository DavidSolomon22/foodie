using System.Collections.Generic;

namespace Entities.RequestFeatures
{
    public class RecipeParameters : RequestParameters
    {
        public ICollection<string> Cuisine { get; set; }
        public ICollection<string> Category { get; set; }
        public int ComplexityLevel { get; set; }
        public string SearchTerm { get; set; }
    }
}
