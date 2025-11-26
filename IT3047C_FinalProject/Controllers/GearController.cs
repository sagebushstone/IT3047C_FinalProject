using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class GearController : Controller
    {
        private HikingContext context {  get; set; }

        public GearController(HikingContext ctx)   
        {
            context = ctx;
        }

        public IActionResult Gear()
        {
            var gears = context.Gears.ToList();
            return View(gears);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Genres = context.Gears.OrderBy(g => g.GearName).ToList();
            return View("Create", new Gear());
        }

        [HttpPost]
        public IActionResult Create(Gear gear)
        {
            if (ModelState.IsValid)
            {
                context.Gears.Add(gear);
                context.SaveChanges();
                return RedirectToAction("Gear");
            }
            return View(gear);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Gears.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Gear gear)
        {
            context.Gears.Remove(gear);
            context.SaveChanges();
            return RedirectToAction("Gear");
        }
    }
}
