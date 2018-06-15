using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Models
{
    public class ExecutiveBllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OrderBllModel> Orders { get; set; }
    }
}
