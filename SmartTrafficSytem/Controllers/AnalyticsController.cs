using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}