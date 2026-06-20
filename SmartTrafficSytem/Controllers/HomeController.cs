using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Models;
using SmartTrafficSystem.Data;
using System.Diagnostics;

namespace SmartTrafficSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrafficDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            TrafficDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var roads = _context.Roads.ToList();

            ViewBag.RoadCount = roads.Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ??
                            HttpContext.TraceIdentifier
            });
        }
    }
}