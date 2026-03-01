using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
