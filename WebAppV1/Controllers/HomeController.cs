using AppCoreV1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppV1.Helpers;
using WebAppV1.Models;

namespace WebAppV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageHelper _helper;

        public HomeController(ILogger<HomeController> logger, IPageHelper helper)
        {
            _logger = logger;
            _helper = helper;
        }

        public IActionResult Index()
        {
            string loginuser = HttpContext.User.Identity?.Name ?? string.Empty;

            ViewData["Title"] = "Home";

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.ToString());

                // redirect to error page
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";
            return View();
        }

        public IActionResult AccessDenied()
        {
            ViewData["Title"] = "AccessDenied";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["Title"] = "Error";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        public IActionResult FAQ()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorOld()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}