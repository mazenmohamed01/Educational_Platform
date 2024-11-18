
using EducationalPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace EducationalPlatform.Controllers
{
    public class HomeController : Controller
    {
        EducationalPlatformContext db = new EducationalPlatformContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[Route("/home/")]
        public IActionResult Index()
        {
            ViewBag.AllCategories = db.Categories.Where(x => x.IsDelete == "false").ToList();
            ViewBag.AllInstructors = db.Instructors.Where(x => x.IsDelete == "false").ToList();
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

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
