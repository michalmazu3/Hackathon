using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class CordinatesEntity : IEntity
    {
        private static int index = 1;

        public CordinatesEntity()
        {
            Id = index++;
        }

        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual FieldEntity Field { get; set; }
    }
}
