using Microsoft.AspNetCore.Mvc;

namespace WebAppV1.Controllers
{
    public class AbleDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
