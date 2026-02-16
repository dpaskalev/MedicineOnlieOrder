using MedicineOnlieOrder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedicineOnlieOrder.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/StatusCodeError/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("PageNotFoundView");
            }
            else
            {
                return View("CustomErrorView");
            }
        }
    }
}
