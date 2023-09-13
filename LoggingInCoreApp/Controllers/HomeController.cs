using LoggingInCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingInCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome";
            _logger.LogInformation("Index method of HomeController execution"); 
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy is calling");
            _logger.LogInformation("Privacy is calling");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}