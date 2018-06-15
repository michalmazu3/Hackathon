using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Models
{
    public class RatingBllModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string User { get; set; }
        public int FieldId { get; set; }
        public FieldBllModel Field { get; set; }
        public string Comment { get; set; }
    }
}
