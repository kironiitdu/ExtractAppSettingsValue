using ExtractAppSettingsValue.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExtractAppSettingsValue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _appSettingsValue;
        private string clusterSettings;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _appSettingsValue = configuration;
            clusterSettings = _appSettingsValue["ClusterSettings:Host"]!;
        }

        public IActionResult Index()
        {
            var getAppSettingsValue = clusterSettings;
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