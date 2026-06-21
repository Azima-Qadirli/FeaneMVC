using Feane.Services.Interfaces;
using Feane.ViewModels.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _service;

        public SliderController(ISliderService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var slider = await _service.GetAllAsync();
            return View(slider);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(SliderCeateVM vm)
        {
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var slider = await _service.GetByIdAsync(id);
            if (slider == null)
                return NotFound();

            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SliderUpdateVM vm)
        {
            await _service.Update(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
