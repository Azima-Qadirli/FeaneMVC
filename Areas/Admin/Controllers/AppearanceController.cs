using Feane.Helper;
using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.Appaeareance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppearanceController : Controller
    {
        private readonly IAppearanceService _service;

        public AppearanceController(IAppearanceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var appearance = await _service.GetAllAsync();
            return View(appearance);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AppaereanceCreateVM vm) //parametr list
        {
            if (!ModelState.IsValid)
                return View(vm);
            if (!vm.ImageName.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View();
            }
            if (!vm.ImageName.CheckType("image"))
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
            var appereance = await _service.GetByIdAsync(id);
            if (appereance == null)
                return NotFound();
            return View(appereance);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppaeareanceUpdateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if(vm.ImageName != null)
            {
            if (!vm.ImageName.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View();
            }
            if (!vm.ImageName.CheckType("image"))
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

