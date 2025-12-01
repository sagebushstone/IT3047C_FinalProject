using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class TrailController : Controller
    {
        private HikingContext context { get; set; }
        private static Random rand {  get; set; }
        private static int prevTrailIdx { get; set; }

        public TrailController(HikingContext ctx)
        {
            context = ctx;
            rand = new Random();
        }

        public IActionResult Trail()
        {
            var trails = context.Trails.ToList();
            return View(trails);
        }

        public IActionResult RandomTrail()
        {
            var allTrails = context.Trails.ToList();
            var randIndex = rand.Next(allTrails.Count);

            // loop so it doesn't return the same trail twice in a row
            while (randIndex == prevTrailIdx)
            {
                randIndex = rand.Next(allTrails.Count);
            }

            var randTrail = allTrails[randIndex];
            prevTrailIdx = randIndex;
            return View(randTrail);
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
