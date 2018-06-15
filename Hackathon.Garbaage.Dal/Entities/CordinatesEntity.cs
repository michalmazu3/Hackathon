using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class CordinatesEntity : IEntity
    {

        public CordinatesEntity()
        {
            //Id = index++;
        }

        public int Id { get; set; }
        [Column(name: "Latitude")]
        public decimal lat { get; set; }
        [Column(name: "Longitude ")]
        public decimal lng{ get; set; }
        public int FieldId { get; set; }

        public virtual FieldEntity Field { get; set; }
    }
}
