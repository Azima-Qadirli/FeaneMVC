using Feane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAppearanceService _service;

        public AboutController(IAppearanceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var appearance = await _service.GetAllAsync();
            return View(appearance);
        }
    }
}
