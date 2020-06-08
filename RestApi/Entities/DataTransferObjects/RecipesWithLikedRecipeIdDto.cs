using System;

namespace Entities.DataTransferObjects
{
    public class RecipesWithLikedRecipeIdDto
    {
        public Guid Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Cuisine { get; set; }
        public DateTime DateCreated { get; set; }
        public int ComplexityLevel { get; set; }
        public int EstimatedTime { get; set; }
        public int LikesNumber { get; set; }
        public Guid? LikedRecipeId { get; set; }
    }
}
