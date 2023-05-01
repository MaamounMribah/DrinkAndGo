using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
