
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("emergencies")]
    public class Emergency
    {
        [Key]
        [Column("emergency_id")]
        public int EmergencyId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("vehicle_type")]
        public string? VehicleType { get; set; }

        [Column("priority_level")]
        public string? PriorityLevel { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}