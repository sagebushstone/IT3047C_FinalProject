using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class TrailController : Controller
    {
        private HikingContext context { get; set; }

        public TrailController(HikingContext ctx)
        {
            context = ctx;
        }

        public IActionResult Trail()
        {
            var trails = context.Trails.ToList();
            return View(trails);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trail trail)
        {
            if (ModelState.IsValid)
            {
                context.Trails.Add(trail);
                context.SaveChanges();
                return RedirectToAction("Trail");
            }
            return View(trail);
        }

        public IActionResult Delete(int id)
        {
            var trail = context.Trails.FirstOrDefault(t => t.TrailId == id);
            if (trail == null)
            {
                return NotFound();
            }
            return View(trail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trail = context.Trails.Find(id);
            if (trail == null)
            {
                return NotFound();
            }

            context.Trails.Remove(trail);
            context.SaveChanges();

            return RedirectToAction("Trail");
        }
    }
}
