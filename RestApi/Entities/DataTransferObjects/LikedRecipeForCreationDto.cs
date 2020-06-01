using System;

namespace Entities.DataTransferObjects
{
    public class LikedRecipeForCreationDto
    {
        public string UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
