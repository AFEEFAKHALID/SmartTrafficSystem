using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("incidents")]
    public class Incident
    {
        [Key]
        [Column("incident_id")]
        public int IncidentId { get; set; }

        [Column("road_id")]
        public int RoadId { get; set; }

        [Column("incident_type")]
        public string? IncidentType { get; set; }

        [Column("severity")]
        public string? Severity { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}