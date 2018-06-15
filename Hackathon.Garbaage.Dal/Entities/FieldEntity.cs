using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class FieldEntity : IEntity
    {
        private static int id = 1;

        public FieldEntity()
        {
            //Id = id++;
            Cordinates = new List<CordinatesEntity>();
            Orders = new List<OrderEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<CordinatesEntity> Cordinates { get; set; }
        public virtual List<OrderEntity> Orders { get; set; }
        public virtual List<RatingEntity> Ratings { get; set; }
    }
}
