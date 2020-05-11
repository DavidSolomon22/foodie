using System;

namespace Entities.DataTransferObjects
{
    public class RateDto
    {
        public Guid Id {get; set;}
        public string AuthorId {get;set;}
        public string Comment {get; set;}
        public int Value {get; set;}
        public DateTime DateCreated {get; set;}
    }
}