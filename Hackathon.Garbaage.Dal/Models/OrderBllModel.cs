﻿using Hackathon.Garbage.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Models
{
    public class OrderBllModel
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public virtual FieldBllModel Field { get; set; }
        public int ExecutiveId { get; set; }
        public virtual ExecutiveBllModel Executive { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime FinishDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
