using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class FieldEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<float> Cordinates { get; set; }
    }
}
