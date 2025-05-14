using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
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
            List<People> people = new List<People>();
            people.Add(new People { Id = 1 ,Name = "Shayam",City = "Kolkata"});
            people.Add(new People { Id = 2 ,Name = "Shayam",City = "Kolkata"});
            people.Add(new People { Id = 3 ,Name = "Shayam",City = "Kolkata"});
            people.Add(new People { Id = 4, Name = "Shayam", City = "Kolkata" });


            return View("Index",people);
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
