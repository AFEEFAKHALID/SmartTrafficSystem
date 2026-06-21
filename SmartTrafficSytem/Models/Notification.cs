using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("notifications")]
    public class Notification
    {
        [Key]
        [Column("notification_id")]
        public int NotificationId { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("message")]
        public string? Message { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}