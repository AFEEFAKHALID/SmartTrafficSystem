using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("signals")]
    public class Signal
    {
        [Key]
        [Column("signal_id")]
        public int SignalId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("red_duration")]
        public int RedDuration { get; set; }

        [Column("yellow_duration")]
        public int YellowDuration { get; set; }

        [Column("green_duration")]
        public int GreenDuration { get; set; }

        [Column("current_status")]
        public string? CurrentStatus { get; set; }
    }
}