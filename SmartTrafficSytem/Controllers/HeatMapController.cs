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

                 select new
                 {
                     r.RoadName,
                     t.VehicleCount,
                     t.TrafficLevel
                 })
                 .OrderByDescending(x => x.VehicleCount)
                 .ToList();

            ViewBag.Roads = roads;

            return View();
        }
    }
}