using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
     
    public class OrderEntity : IEntity
    {
        private static int id = 1;

        public OrderEntity()
        {
        }

        public OrderEntity(FieldEntity field)
        {
            //Field = field;
            //Id = id++;
            FieldId = field.Id;
            DeadlineDate = new DateTime(2018, 06, 11);
            FinishDate = new DateTime(2018, 06, 10);
            Status = OrderStatus.FINISHED;
        }

        public int Id { get; set; }
        public int FieldId { get; set; }
        public int ExecutiveId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public OrderStatus Status { get; set; }


        public virtual FieldEntity Field { get; set; }
        public virtual ExecutiveEntity Executive { get; set; }
        public virtual List<PhotoEntity> Photos { get; set; }

    }
    public enum OrderStatus
    {
        FINISHED,
        IN_PROGRESS
    }
}
