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
    }
}
