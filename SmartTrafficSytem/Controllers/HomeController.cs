using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using SmartTrafficSystem.Models;
using System.Diagnostics;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrafficDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            TrafficDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard Counts

            ViewBag.RoadCount =
                _context.Roads.Count();

            ViewBag.VehicleCount =
                _context.Vehicles.Count();

            ViewBag.EmergencyCount =
                _context.Emergencies.Count();

            ViewBag.SignalCount =
                _context.Signals.Count();

            ViewBag.TrafficCount =
                _context.TrafficData.Count();

            // Vehicle Statistics

            ViewBag.CarCount =
                _context.Vehicles
                .Where(v => v.VehicleType == "Car")
                .Sum(v => (int?)v.VehicleCount) ?? 0;

            ViewBag.BikeCount =
                _context.Vehicles
                .Where(v => v.VehicleType == "Bike")
                .Sum(v => (int?)v.VehicleCount) ?? 0;

            ViewBag.TruckCount =
                _context.Vehicles
                .Where(v => v.VehicleType == "Truck")
                .Sum(v => (int?)v.VehicleCount) ?? 0;

            ViewBag.BusCount =
                _context.Vehicles
                .Where(v => v.VehicleType == "Bus")
                .Sum(v => (int?)v.VehicleCount) ?? 0;

            ViewBag.ScootyCount =
                _context.Vehicles
                .Where(v => v.VehicleType == "Scooty")
                .Sum(v => (int?)v.VehicleCount) ?? 0;

            ViewBag.TotalVehicles =
                ViewBag.CarCount +
                ViewBag.BikeCount +
                ViewBag.TruckCount +
                ViewBag.BusCount +
                ViewBag.ScootyCount;

            // Latest Emergency

            var emergencyInfo =
                (from e in _context.Emergencies
                 join r in _context.Roads
                 on e.RoadId equals r.RoadId

                 orderby e.CreatedAt descending

                 select new
                 {
                     e.VehicleType,
                     e.PriorityLevel,
                     e.Status,
                     r.RoadName
                 })
                 .FirstOrDefault();

            ViewBag.EmergencyInfo =
                emergencyInfo;

            // Latest Signal

            var latestSignal =
                _context.Signals
                .OrderByDescending(s => s.SignalId)
                .FirstOrDefault();

            ViewBag.LatestSignal =
                latestSignal;

            // ====================================
            // AUTOMATIC EMERGENCY PRIORITY ROUTING
            // ====================================

            var activeEmergency =
                (from e in _context.Emergencies

                 join r in _context.Roads
                 on e.RoadId equals r.RoadId

                 where e.Status == "Active"

                 orderby e.CreatedAt descending

                 select new
                 {
                     e.RoadId,
                     r.RoadName,
                     e.VehicleType,
                     e.PriorityLevel
                 })
                 .FirstOrDefault();

            if (activeEmergency != null)
            {
                var signal =
                    _context.Signals
                    .FirstOrDefault(s =>
                        s.RoadId == activeEmergency.RoadId);

                if (signal != null)
                {
                    signal.CurrentStatus = "Green";

                    _context.SaveChanges();
                }

                ViewBag.EmergencyAlert = true;

                ViewBag.EmergencyRoad =
                    activeEmergency.RoadName;

                ViewBag.EmergencyVehicle =
                    activeEmergency.VehicleType;

                ViewBag.EmergencyPriority =
                    activeEmergency.PriorityLevel;
            }
            else
            {
                ViewBag.EmergencyAlert = false;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id ??
                    HttpContext.TraceIdentifier
            });
        }
    }
}