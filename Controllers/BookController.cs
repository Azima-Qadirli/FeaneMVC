using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookTableService _service;

        public BookController(IBookTableService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var tables = await _service.GetAllAsync();
            return View(tables);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookTableCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (vm.Date.Date < DateTime.UtcNow.Date)
            {
                ModelState.AddModelError("Date", "Zəhmət olmasa bu günü və ya gələcək bir günü seçin.");
                return View(vm);
            }
            await _service.CreateAsync(vm);
            TempData["BookingSuccess"] = "Masanız uğurla rezerv olundu! Sizi gözləyirik.";
            return RedirectToAction("Index", "Home");

        }
    }
}
