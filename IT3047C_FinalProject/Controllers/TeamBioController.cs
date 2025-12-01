using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers
{
    public class TeamBioController : Controller
    {
        public IActionResult Bio()
        {
            return View();
        }
    }
}