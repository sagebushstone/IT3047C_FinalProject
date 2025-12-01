using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT3047C_FinalProject.Models;

namespace IT3047C_FinalProject.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly HikingContext _context;

        public RecommendationController(HikingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recs = _context.Recommendations
                .Include(r => r.Trail)
                .ToList();
            return View(recs);
        }

        public IActionResult Details(int id)
        {
            var rec = _context.Recommendations
                .Include(r => r.Trail)
                .Include(r => r.Items).ThenInclude(i => i.Gear)
                .FirstOrDefault(r => r.RecommendationId == id);

            if (rec == null) return NotFound();
            return View(rec);
        }

        public IActionResult Create()
        {
            ViewBag.Trails = _context.Trails.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recommendation recommendation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Trails = _context.Trails.ToList();
                return View(recommendation);
            }

            _context.Recommendations.Add(recommendation);
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = recommendation.RecommendationId });
        }

        public IActionResult CreateAndEdit(int trailId)
        {
            var rec = _context.Recommendations
                .Include(r => r.Items)
                .FirstOrDefault(r => r.TrailId == trailId);

            if (rec == null)
            {
                rec = new Recommendation
                {
                    TrailId = trailId
                };
                _context.Recommendations.Add(rec);
                _context.SaveChanges();
            }

            return RedirectToAction("Edit", new { id = rec.RecommendationId });
        }

        public IActionResult Edit(int id)
        {
            var rec = _context.Recommendations
                .Include(r => r.Trail)
                .Include(r => r.Items).ThenInclude(i => i.Gear)
                .FirstOrDefault(r => r.RecommendationId == id);

            if (rec == null) return NotFound();

            ViewBag.AllGears = _context.Gears.ToList();
            return View(rec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAllItems(RecommendationEditViewModel model)
        {
            if (model == null) return BadRequest();

            if (model.Items == null || !model.Items.Any())
            {
                return RedirectToAction(nameof(Edit), new { id = model.RecommendationId });
            }

            foreach (var posted in model.Items)
            {
                var entity = _context.RecommendationItems.Find(posted.RecommendationItemId);
                if (entity == null) continue;

                var qty = posted.Quantity < 1 ? 1 : posted.Quantity;
                if (entity.Quantity != qty)
                {
                    entity.Quantity = qty;
                }
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Edit), new { id = model.RecommendationId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(int recommendationId, int gearId, int quantity)
        {
            if (quantity < 1) ModelState.AddModelError(nameof(quantity), "Quantity must be at least 1");

            if (!ModelState.IsValid) return RedirectToAction(nameof(Edit), new { id = recommendationId });

            var item = new RecommendationItem
            {
                RecommendationId = recommendationId,
                GearId = gearId,
                Quantity = quantity
            };

            _context.RecommendationItems.Add(item);
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = recommendationId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(int recommendationItemId, int quantity)
        {
            var item = _context.RecommendationItems.Find(recommendationItemId);
            if (item == null) return NotFound();

            item.Quantity = quantity;
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = item.RecommendationId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int recommendationItemId)
        {
            var item = _context.RecommendationItems.Find(recommendationItemId);
            if (item == null) return NotFound();

            var recId = item.RecommendationId;
            _context.RecommendationItems.Remove(item);
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = recId });
        }

        public IActionResult Delete(int id)
        {
            var rec = _context.Recommendations
                .Include(r => r.Trail)
                .FirstOrDefault(r => r.RecommendationId == id);

            if (rec == null) return NotFound();
            return View(rec);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rec = _context.Recommendations.Find(id);
            if (rec == null) return NotFound();

            _context.Recommendations.Remove(rec);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
