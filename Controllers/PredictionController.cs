using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class PredictionController : Controller
    {
        private readonly TrafficDbContext _context;

        public PredictionController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var predictions =
                (from t in _context.TrafficData

                 join r in _context.Roads
                 on t.RoadId equals r.RoadId

                 where t.TrafficId ==
                     _context.TrafficData
                     .Where(x => x.RoadId == t.RoadId)
                     .Max(x => x.TrafficId)

                 select new
                 {
                     r.RoadName,

                     CurrentTraffic = t.VehicleCount,

                     PredictedTraffic =
                         t.VehicleCount +
                         (int)(t.VehicleCount * 0.10),

                     RiskLevel =
                         (t.VehicleCount +
                         (int)(t.VehicleCount * 0.10)) > 1000
                         ? "High Risk"
                         : "Normal"
                 })
                 .OrderByDescending(x => x.PredictedTraffic)
                 .ToList();

            ViewBag.Predictions = predictions;

            ViewBag.RoadNames =
                predictions.Select(x => x.RoadName).ToList();

            ViewBag.CurrentTraffic =
                predictions.Select(x => x.CurrentTraffic).ToList();

            ViewBag.PredictedTraffic =
                predictions.Select(x => x.PredictedTraffic).ToList();

            ViewBag.TotalPredictions =
                predictions.Count();

            ViewBag.HighRiskRoads =
                predictions.Count(x =>
                    x.RiskLevel == "High Risk");

            return View();
        }
    }
}