using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class EmergencyHistoryController : Controller
    {
        private readonly TrafficDbContext _context;

        public EmergencyHistoryController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var history =
                (from h in _context.EmergencyHistory
                 join r in _context.Roads
                 on h.RoadId equals r.RoadId

                 orderby h.CompletedAt descending

                 select new
                 {
                     r.RoadName,
                     h.VehicleType,
                     h.PriorityLevel,
                     h.Status,
                     h.CompletedAt
                 })
                 .ToList();

            ViewBag.History = history;

            ViewBag.TotalHistory =
                _context.EmergencyHistory.Count();

            return View();
        }
    }
}