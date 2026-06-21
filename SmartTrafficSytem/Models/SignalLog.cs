using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("signal_logs")]
    public class SignalLog
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("previous_status")]
        public string? PreviousStatus { get; set; }

        [Column("new_status")]
        public string? NewStatus { get; set; }

        [Column("reason")]
        public string? Reason { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}