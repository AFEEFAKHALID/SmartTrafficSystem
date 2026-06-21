using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using SmartTrafficSystem.Models;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class SignalController : Controller
    {
        private readonly TrafficDbContext _context;

        public SignalController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalSignals =
                _context.Signals.Count();

            ViewBag.GreenSignals =
                _context.Signals.Count(s =>
                    s.CurrentStatus == "Green");

            ViewBag.YellowSignals =
                _context.Signals.Count(s =>
                    s.CurrentStatus == "Yellow");

            ViewBag.RedSignals =
                _context.Signals.Count(s =>
                    s.CurrentStatus == "Red");

            ViewBag.EmergencyRoutes =
                _context.Emergencies
                    .Select(e => e.RoadId)
                    .Distinct()
                    .Count();

            var signals =
                (from s in _context.Signals

                 join r in _context.Roads
                 on s.RoadId equals r.RoadId

                 orderby r.RoadName

                 select new
                 {
                     s.SignalId,
                     r.RoadName,
                     s.RedDuration,
                     s.YellowDuration,
                     s.GreenDuration,
                     s.CurrentStatus
                 })
                 .ToList();

            ViewBag.SignalData = signals;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateSignal(int signalId, string status)
        {
            var signal =
                _context.Signals
                    .FirstOrDefault(s =>
                        s.SignalId == signalId);

            if (signal != null)
            {
                signal.CurrentStatus = status;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}