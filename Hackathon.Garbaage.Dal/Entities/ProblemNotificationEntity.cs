using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Garbage.Dal.Entities
{
    [Table(name: "ProblemNotification")]
    public class ProblemNotificationEntity : IEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string UrlImage { get; set; }
    }
}
