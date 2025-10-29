using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class GearController : Controller
    {
        private HikingContext context {  get; set; }

        private GearController(HikingContext ctx)   
        {
            context = ctx;
        }
    }
}
