using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class IncidentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}