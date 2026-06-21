using Microsoft.AspNetCore.Mvc;
using SmartTrafficSystem.Data;

namespace SmartTrafficSystem.Controllers
{
    public class VehicleController : Controller
    {
        private readonly TrafficDbContext _context;

        public VehicleController(TrafficDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();

            return View(vehicles);
        }
    }
}