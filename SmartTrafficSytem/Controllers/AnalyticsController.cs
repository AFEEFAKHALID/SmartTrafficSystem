using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly TrafficDbContext _context;

        public AnalyticsController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard Cards

            ViewBag.TotalRoads =
                _context.Roads.Count();

            ViewBag.TotalVehicles =
                _context.TrafficData.Sum(x => x.VehicleCount);

            ViewBag.TotalEmergencies =
                _context.Emergencies.Count();

            ViewBag.TotalSignals =
                _context.Signals.Count();

            // Traffic Distribution

            ViewBag.CriticalCount =
                _context.TrafficData.Count(x =>
                    x.TrafficLevel == "Critical");

            ViewBag.HeavyCount =
                _context.TrafficData.Count(x =>
                    x.TrafficLevel == "Heavy");

            ViewBag.HighCount =
                _context.TrafficData.Count(x =>
                    x.TrafficLevel == "High");

            ViewBag.MediumCount =
                _context.TrafficData.Count(x =>
                    x.TrafficLevel == "Medium");

            ViewBag.LowCount =
                _context.TrafficData.Count(x =>
                    x.TrafficLevel == "Low");

            // Vehicle Chart

            var chartData =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.VehicleCount descending
                 select new
                 {
                     r.RoadName,
                     t.VehicleCount
                 })
                 .Take(10)
                 .ToList();

            ViewBag.RoadNames =
                chartData.Select(x => x.RoadName).ToList();

            ViewBag.VehicleCounts =
                chartData.Select(x => x.VehicleCount).ToList();

            // Most Congested Road

            ViewBag.TopRoad =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.VehicleCount descending
                 select r.RoadName)
                 .FirstOrDefault();

            // Fastest Road

            ViewBag.FastestRoad =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.AverageSpeed descending
                 select r.RoadName)
                 .FirstOrDefault();

            // Average Speed

            ViewBag.AverageSpeed =
                Math.Round(
                    _context.TrafficData
                    .Average(x => x.AverageSpeed), 2);

            // Emergency Vehicle Analytics

            ViewBag.AmbulanceCount =
                _context.Emergencies
                .Count(e => e.VehicleType == "Ambulance");

            ViewBag.FireBrigadeCount =
                _context.Emergencies
                .Count(e => e.VehicleType == "Fire Brigade");

            // Top Congested Roads

            ViewBag.TopRoads =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId
                 orderby t.VehicleCount descending
                 select new
                 {
                     r.RoadName,
                     t.VehicleCount,
                     t.TrafficLevel
                 })
                 .Take(5)
                 .ToList();

            ViewBag.MostCommonTraffic =
                _context.TrafficData
                .GroupBy(x => x.TrafficLevel)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            return View();
        }
    }
}