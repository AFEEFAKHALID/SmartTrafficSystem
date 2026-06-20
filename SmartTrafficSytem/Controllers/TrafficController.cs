using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class TrafficController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}