using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class TrafficController : Controller
    {
        private readonly TrafficDbContext _context;

        public TrafficController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard Cards

            ViewBag.TotalRoads = _context.Roads.Count();

            ViewBag.LowTrafficRoads =
                _context.TrafficData.Count(t => t.TrafficLevel == "Low");

            ViewBag.HighTrafficRoads =
                _context.TrafficData.Count(t =>
                    t.TrafficLevel == "High" ||
                    t.TrafficLevel == "Heavy" ||
                    t.TrafficLevel == "Critical");

            ViewBag.EmergencyRoutes =
                _context.Emergencies
                    .Select(e => e.RoadId)
                    .Distinct()
                    .Count();
            ViewBag.CriticalCount =
    _context.TrafficData.Count(t => t.TrafficLevel == "Critical");

            ViewBag.HeavyCount =
                _context.TrafficData.Count(t => t.TrafficLevel == "Heavy");

            ViewBag.HighCount =
                _context.TrafficData.Count(t => t.TrafficLevel == "High");

            ViewBag.MediumCount =
                _context.TrafficData.Count(t => t.TrafficLevel == "Medium");

            ViewBag.LowCount =
                _context.TrafficData.Count(t => t.TrafficLevel == "Low");

            // Traffic Monitoring Table

            var trafficData =
 (
     from t in _context.TrafficData

     join r in _context.Roads
         on t.RoadId equals r.RoadId

     where t.TrafficId ==
         _context.TrafficData
             .Where(x => x.RoadId == t.RoadId)
             .Max(x => x.TrafficId)

     select new
     {
         r.RoadName,

         t.VehicleCount,

         t.TrafficLevel,

         t.AverageSpeed,

         SignalStatus =
             _context.Signals
                 .Where(s => s.RoadId == t.RoadId)
                 .OrderByDescending(s => s.SignalId)
                 .Select(s => s.CurrentStatus)
                 .FirstOrDefault() ?? "N/A",

         EmergencyVehicle =
             _context.Emergencies
                 .Where(e => e.RoadId == t.RoadId)
                 .OrderByDescending(e => e.EmergencyId)
                 .Select(e => e.VehicleType)
                 .FirstOrDefault() ?? "None",

         PriorityLevel =
             _context.Emergencies
                 .Where(e => e.RoadId == t.RoadId)
                 .OrderByDescending(e => e.EmergencyId)
                 .Select(e => e.PriorityLevel)
                 .FirstOrDefault() ?? "-"
     }

 ).OrderByDescending(x => x.VehicleCount)
  .ToList();

            ViewBag.TrafficData = trafficData;

            var chartData =
    (
        from t in _context.TrafficData
        join r in _context.Roads
            on t.RoadId equals r.RoadId

        where t.TrafficId ==
            _context.TrafficData
                .Where(x => x.RoadId == t.RoadId)
                .Max(x => x.TrafficId)

        orderby t.VehicleCount descending

        select new
        {
            r.RoadName,
            t.VehicleCount
        }

    ).ToList();

            ViewBag.RoadNames =
                chartData.Select(x => x.RoadName).ToList();

            ViewBag.VehicleCounts =
                chartData.Select(x => x.VehicleCount).ToList();


            return View();
        }
    }
}