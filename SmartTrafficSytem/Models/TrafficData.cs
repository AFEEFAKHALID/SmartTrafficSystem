using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("traffic_data")]
    public class TrafficData
    {
        public int TrafficId { get; set; }

        public int RoadId { get; set; }

        public int VehicleCount { get; set; }

        public string? TrafficLevel { get; set; }

        public decimal AverageSpeed { get; set; }

        public DateTime RecordedAt { get; set; }
    }
}