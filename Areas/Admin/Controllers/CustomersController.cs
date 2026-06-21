using Feane.Helper;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        public CustomersController(ICustomersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var customer = await _service.GetAllAsync();
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customers = await _service.GetByIdAsync(id);
            if (customers == null)
                return NotFound();
            return View(customers);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomersUpdateVM vm)
        {

            if (!ModelState.IsValid)
                return View(vm);
            if (vm.ImageName != null)
            {
                if (!vm.ImageName.CheckSize(2))
                {
                    ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                    return View(vm);
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
