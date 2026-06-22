using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("roads")]
    public class Road
    {
        [Key]
        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("road_name")]
        public string? RoadName { get; set; }

        [Column("area_name")]
        public string? AreaName { get; set; }

        [Column("total_lanes")]
        public int TotalLanes { get; set; }

        [Column("speed_limit")]
        public int SpeedLimit { get; set; }

        [Column("status")]
        public string? Status { get; set; }
    }
}