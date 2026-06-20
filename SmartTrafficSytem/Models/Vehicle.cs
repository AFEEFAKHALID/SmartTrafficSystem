using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrafficSystem.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string? VehicleType { get; set; }

        public string? RegistrationNumber { get; set; }
    }
}