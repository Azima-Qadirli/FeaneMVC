using Feane.Helper;
using Feane.Services.Interfaces;
using Feane.ViewModels.Dish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly IDishService _service;

        public DishController(IDishService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DishCreateVM vm) //parametr list 
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (!vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View(vm);
            }
            if (!vm.Image.CheckType("image"))
            {
                ModelState.AddModelError("Image", "Zehmet olmasa image data yukleyin");
                return View(vm);
            }
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
            var Dish = await _service.GetByIdAsync(id);
            DishUpdateVM vm = Dish;
            if (Dish == null)
                return NotFound();
            return View(Dish);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DishUpdateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (vm.Image != null)
            {

                if (!vm.Image.CheckSize(2))
                {
                    ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                    return View(vm);
                }
                if (!vm.Image.CheckType("image"))
                {
                    ModelState.AddModelError("Image", "Zehmet olmasa image data yukleyin");
                    return View(vm);
                }
            }
            await _service.Update(vm);
            return RedirectToAction(nameof(Index));
        }

    }
}

