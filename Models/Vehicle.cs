using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        [Column("vehicle_id")]
        public int VehicleId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("vehicle_type")]
        public string? VehicleType { get; set; }

        [Column("vehicle_count")]
        public int VehicleCount { get; set; }

        [Column("recorded_at")]
        public DateTime RecordedAt { get; set; }
    }
}