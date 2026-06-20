using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("emergencies")]
    public class Emergency
    {
        public int EmergencyId { get; set; }

        public string? EmergencyType { get; set; }

        public int RoadId { get; set; }

        public string? Status { get; set; }
    }
}