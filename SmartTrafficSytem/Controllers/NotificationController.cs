using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;
using System.Linq;

namespace SmartTrafficSystem.Controllers
{
    public class NotificationController : Controller
    {
        private readonly TrafficDbContext _context;

        public NotificationController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalNotifications =
                _context.Notifications.Count();

            ViewBag.EmergencyAlerts =
                _context.Notifications
                .Count(n => n.Type == "Emergency");

            ViewBag.TrafficAlerts =
                _context.Notifications
                .Count(n => n.Type == "Traffic");

            ViewBag.IncidentAlerts =
                _context.Notifications
                .Count(n => n.Type == "Incident");

            var notifications =
                _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            ViewBag.Notifications = notifications;

            return View();
        }
    }
}