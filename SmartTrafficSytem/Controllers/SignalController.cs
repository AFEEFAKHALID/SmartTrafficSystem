using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class SignalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}