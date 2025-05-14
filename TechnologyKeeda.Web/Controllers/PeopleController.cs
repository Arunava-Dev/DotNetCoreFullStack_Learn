using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Web.Data;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.People.ToList();

            return View(people);
        }
        //HttpGet ,HttpPost
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.Add(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.People.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Edit(People people)
        {
            _context.People.Update(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.People.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Delete(People people)
        {
            _context.People.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
