using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Models
{
    public class FieldBllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  List<CordinatesBllModel> Cordinates { get; set; }
        public  List<OrderBllModel> Orders { get; set; }
        public List<RatingBllModel> Ratings { get; set; }
    }
}
