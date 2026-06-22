using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class HeatMapController : Controller
    {
        private readonly TrafficDbContext _context;

        public HeatMapController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var roads =
                (from t in _context.TrafficData
                 join r in _context.Roads
                 on t.RoadId equals r.RoadId

                 group new { t, r }
                 by new
                 {
                     r.RoadId,
                     r.RoadName
                 }
                 into g

                 select new
                 {
                     RoadName = g.Key.RoadName,
                     VehicleCount = g.Max(x => x.t.VehicleCount),
                     TrafficLevel = g
                         .OrderByDescending(x => x.t.VehicleCount)
                         .FirstOrDefault()
                         .t.TrafficLevel
                 })
                 .OrderByDescending(x => x.VehicleCount)
                 .ToList();

            ViewBag.Roads = roads;

            return View();
        }
    }
}