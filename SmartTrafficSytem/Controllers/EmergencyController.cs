using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class EmergencyController : Controller
    {
        private readonly TrafficDbContext _context;

        public EmergencyController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard Cards

            ViewBag.TotalEmergencies =
                _context.Emergencies.Count();

            ViewBag.ActiveEmergencies =
                _context.Emergencies.Count(e =>
                    e.Status == "Active");

            ViewBag.HighPriority =
                _context.Emergencies.Count(e =>
                    e.PriorityLevel == "High");

            ViewBag.AmbulanceCount =
                _context.Emergencies.Count(e =>
                    e.VehicleType == "Ambulance");

            ViewBag.FireBrigadeCount =
                _context.Emergencies.Count(e =>
                    e.VehicleType == "Fire Brigade");

            // Emergency Table

            var emergencyData =
                (from e in _context.Emergencies

                 join r in _context.Roads
                 on e.RoadId equals r.RoadId

                 orderby e.CreatedAt descending

                 select new
                 {
                     e.EmergencyId,
                     r.RoadName,
                     e.VehicleType,
                     e.PriorityLevel,
                     e.Status,
                     e.CreatedAt
                 })
                 .ToList();

            ViewBag.EmergencyData = emergencyData;

            return View();
        }
    }
}