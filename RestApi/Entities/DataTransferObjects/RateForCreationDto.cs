using System;

namespace Entities.DataTransferObjects
{
    public class RateForCreationDto
    {
        public Guid RecipeId {get; set;}
        public string AuthorId {get;set;}
        public string Comment {get; set;}
        public int? Value {get; set;}

    }
}