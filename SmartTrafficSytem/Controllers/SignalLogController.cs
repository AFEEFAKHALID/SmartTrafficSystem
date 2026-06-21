using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class SignalLogController : Controller
    {
        private readonly TrafficDbContext _context;

        public SignalLogController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var logs =
                (from l in _context.SignalLogs
                 join r in _context.Roads
                 on l.RoadId equals r.RoadId

                 orderby l.CreatedAt descending

                 select new
                 {
                     r.RoadName,
                     l.PreviousStatus,
                     l.NewStatus,
                     l.Reason,
                     l.CreatedAt
                 })
                 .ToList();

            ViewBag.Logs = logs;

            ViewBag.TotalLogs =
                _context.SignalLogs.Count();

            return View();
        }
    }
}