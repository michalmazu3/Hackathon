using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual FieldEntity Field { get; set; }
    }
}
