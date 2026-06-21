using Feane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Feane.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDishService _service;

        public MenuController(IDishService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var dishes = await _service.GetAllAsync();
            return View(dishes);
        }
    }
}
