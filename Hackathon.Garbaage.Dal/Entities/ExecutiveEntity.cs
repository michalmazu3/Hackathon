using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class ExecutiveEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get;set;}

        public virtual List<OrderEntity> Orders { get; set; }
    }
}
