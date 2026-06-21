using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class IncidentController : Controller
    {
        private readonly TrafficDbContext _context;

        public IncidentController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard Cards

            ViewBag.TotalIncidents =
                _context.Incidents.Count();

            ViewBag.OpenIncidents =
                _context.Incidents.Count(i => i.Status == "Open");

            ViewBag.ResolvedIncidents =
                _context.Incidents.Count(i => i.Status == "Resolved");

            ViewBag.CriticalIncidents =
                _context.Incidents.Count(i => i.Severity == "Critical");

            // Incident Table

            var incidents =
                (from i in _context.Incidents
                 join r in _context.Roads
                 on i.RoadId equals r.RoadId

                 orderby i.CreatedAt descending

                 select new
                 {
                     i.IncidentType,
                     r.RoadName,
                     i.Severity,
                     i.Status,
                     i.Description,
                     i.CreatedAt
                 })
                 .ToList();

            ViewBag.Incidents = incidents;

            return View();
        }
    }
}