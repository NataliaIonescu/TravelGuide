using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using TravelGuide.Models;

namespace TravelGuide.Controllers
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
        [Authorize(Roles = "Admin,User")]
        public IActionResult About()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Gallery()
        {
            List<string> photoUrls = new List<string>
            {
                "/images/gallery/amsterdam.jpg",
                "/images/gallery/athens.jpg",
                "/images/gallery/beijing.jpg",
                "/images/gallery/berlin.jpg",
                "/images/gallery/bucharest.jpg",
                "/images/gallery/dubai.jpg",
                "/images/gallery/giza.jpg",
                "/images/gallery/istanbul.jpg",
                "/images/gallery/london.jpg",
                "/images/gallery/moscow.jpg",
                "/images/gallery/newdelhi.jpg",
                "/images/gallery/newyork.jpg",
                "/images/gallery/paris.jpg",
                "/images/gallery/prague.jpg",
                "/images/gallery/rome.jpg",
                "/images/gallery/tokyo.jpg",

            };

            ViewBag.PhotoUrls = photoUrls;
            return View();
        }

        [HttpPost]
        public IActionResult GetStarted()
        {

             return RedirectToAction("Index", "Cities"); // Redirect to a suitable action after booking
           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}