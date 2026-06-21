using Feane.Helper;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService _service;

        public CustomerController(ICustomersService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomersCreateVM vm) // parametr list                                                                
        {
            if (!ModelState.IsValid)
                return View(vm);
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
            await _service.CreateAsync(vm);
            return RedirectToAction("Index","Home");

        }
       
    }
}
