using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Models
{
    public class CordinatesBllModel
    {
        public int Id { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public int FieldId { get; set; }

        public FieldBllModel Field { get; set; }
    }
}
