using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class TrailController : Controller
    {
        private HikingContext context { get; set; }

        private TrailController(HikingContext ctx)
        {
            context = ctx;
        }

    }
}
