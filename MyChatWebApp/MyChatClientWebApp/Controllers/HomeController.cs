using Microsoft.AspNetCore.Mvc;
using MyChatClientWebApp.Models;
using System.Diagnostics;

namespace MyChatClientWebApp.Controllers
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
            return View();
        }

        public IActionResult Chat1()
        {
            return View();
        }

        public IActionResult Chat2()
        {
            return View();
        }

        public IActionResult Chat3()
        {
            return View();
        }

        public IActionResult Chat4()
        {
            return View();
        }

        public IActionResult Chat5()
        {
            return View();
        }
        public IActionResult Chat6()
        {
            return View();
        }
        public IActionResult Chat7()
        {
            return View();
        }
        public IActionResult Chat8()
        {
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