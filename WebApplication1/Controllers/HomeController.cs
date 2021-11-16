using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyService _myService;

        public HomeController(ILogger<HomeController> logger,MyService myService)
        {
            _logger = logger;
            _myService = myService;
        }

        public IActionResult Index()
        {
            ViewData["myMoney"] = _myService.ShowMyMoney();
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