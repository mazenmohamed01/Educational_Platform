
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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            //List<Instructor> AllInstructors = db.Instructors.ToList();
            List<Instructor> topInstructors = db.Instructors.OrderBy(i => Guid.NewGuid()).Take(4).ToList();

            return View(topInstructors);
        }

        public IActionResult Categories()
        {
            List<Category> AllCategories = db.Categories.ToList();
            return View(AllCategories);
        }


        public IActionResult OurTeam()
        {
            List<Instructor> AllInstructors = db.Instructors.ToList();
            return View(AllInstructors);
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
