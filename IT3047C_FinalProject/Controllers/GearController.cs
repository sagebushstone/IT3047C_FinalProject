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
    }
}
