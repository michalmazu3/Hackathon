using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
     
    public class OrderEntity : IEntity
    {
        private static int id = 1;
        public OrderEntity(FieldEntity field)
        {
            Field = field;
            Id = id++;
            FieldId = field.Id;
            DeadlineDate = new DateTime(2018, 06, 11);
            FinishDate = new DateTime(2018, 06, 10);
        }

        public int Id { get; set; }
        public int FieldId { get; set; }
        public FieldEntity Field { get; set; }
        public int ExecutiveId { get; set; }
        public ExecutiveEntity Executive { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
