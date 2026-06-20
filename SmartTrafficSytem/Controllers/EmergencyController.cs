using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class EmergencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}