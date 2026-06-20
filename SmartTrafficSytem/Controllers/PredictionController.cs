using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class PredictionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}