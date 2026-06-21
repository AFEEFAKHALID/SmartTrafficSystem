using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("traffic_data")]
    public class TrafficData
    {
        [Key]
        [Column("traffic_id")]
        public int TrafficId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("vehicle_count")]
        public int VehicleCount { get; set; }

        [Column("traffic_level")]
        public string? TrafficLevel { get; set; }

        [Column("average_speed")]
        public decimal AverageSpeed { get; set; }

        [Column("recorded_at")]
        public DateTime RecordedAt { get; set; }
    }
}