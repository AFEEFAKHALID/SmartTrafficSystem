using Microsoft.AspNetCore.Mvc;

namespace SmartTrafficSystem.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}