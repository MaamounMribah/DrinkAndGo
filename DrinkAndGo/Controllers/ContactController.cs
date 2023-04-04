using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
