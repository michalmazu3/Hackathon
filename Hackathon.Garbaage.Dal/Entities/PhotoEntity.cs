using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class PhotoEntity : IEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? OrderId { get; set; }
        public int? RatingId { get; set; }

        public virtual OrderEntity Order {get;set;}
        public virtual RatingEntity Rating { get; set; }
    }
}
