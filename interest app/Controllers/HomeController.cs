using System.Diagnostics;
using interest_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace interest_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new InterestCal());
        }

        [HttpPost]
        public IActionResult Index(InterestCal interest)
        {
            if (ModelState.IsValid)
            {

                return View(interest);
            }
            return View(interest);
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
