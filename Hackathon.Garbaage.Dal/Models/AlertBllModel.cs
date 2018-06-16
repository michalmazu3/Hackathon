using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Models
{
    public class AlertBllModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
