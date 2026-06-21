using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("emergency_history")]
    public class EmergencyHistory
    {
        [Key]
        [Column("history_id")]
        public int HistoryId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("vehicle_type")]
        public string? VehicleType { get; set; }

        [Column("priority_level")]
        public string? PriorityLevel { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("completed_at")]
        public DateTime CompletedAt { get; set; }
    }
}