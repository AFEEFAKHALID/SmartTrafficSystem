using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly TrafficDbContext _context;

        public ReportController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalRoads =
                _context.Roads.Count();

            ViewBag.TotalVehicles =
                _context.TrafficData.Sum(t => t.VehicleCount);

            ViewBag.TotalSignals =
                _context.Signals.Count();

            ViewBag.TotalEmergencies =
                _context.Emergencies.Count();

            ViewBag.AverageSpeed =
                _context.TrafficData.Any()
                ? Math.Round(
                    _context.TrafficData
                    .Average(t => t.AverageSpeed), 2)
                : 0;

            ViewBag.TopRoad =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.VehicleCount descending
                 select r.RoadName)
                 .FirstOrDefault() ?? "N/A";

            ViewBag.FastestRoad =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.AverageSpeed descending
                 select r.RoadName)
                 .FirstOrDefault() ?? "N/A";

            ViewBag.ActiveEmergencyRoutes =
                _context.Emergencies
                .Count(e => e.Status == "Active");

            var chartData =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 select new
                 {
                     r.RoadName,
                     t.VehicleCount
                 })
                 .ToList();

            ViewBag.RoadNames =
                chartData.Select(x => x.RoadName).ToList();

            ViewBag.VehicleCounts =
                chartData.Select(x => x.VehicleCount).ToList();

            ViewBag.CriticalCount =
                _context.TrafficData.Count(x => x.TrafficLevel == "Critical");

            ViewBag.HeavyCount =
                _context.TrafficData.Count(x => x.TrafficLevel == "Heavy");

            ViewBag.HighCount =
                _context.TrafficData.Count(x => x.TrafficLevel == "High");

            ViewBag.MediumCount =
                _context.TrafficData.Count(x => x.TrafficLevel == "Medium");

            ViewBag.LowCount =
                _context.TrafficData.Count(x => x.TrafficLevel == "Low");

            return View();
        }
    }
}