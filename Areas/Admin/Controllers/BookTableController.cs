using Feane.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookTableController : Controller
    {
        private readonly IBookTableService _service;

        public BookTableController(IBookTableService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }

}
