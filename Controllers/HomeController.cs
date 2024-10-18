using ASP_.net_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; // Import this namespace
using System.Diagnostics;

namespace ASP_.net_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _greetingMessage; // Declare a variable to hold the greeting message

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration) // Add IConfiguration parameter
        {
            _logger = logger;
            _greetingMessage = configuration["GreetingMessage"]; // Read the value from appsettings.json
        }

        public IActionResult Index()
        {
            ViewData["GreetingMessage"] = _greetingMessage; // Pass the greeting message to the view
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
