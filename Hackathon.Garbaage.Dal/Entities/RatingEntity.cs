﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Entities
{
    public class RatingEntity : IEntity
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string User { get; set; }
    }
}
