using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("signals")]
    public class Signal
    {
        public int SignalId { get; set; }

        public int RoadId { get; set; }

        public string? SignalStatus { get; set; }

        public int GreenDuration { get; set; }

        public int YellowDuration { get; set; }

        public int RedDuration { get; set; }
    }
}