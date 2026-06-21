using Feane.Context;
using Feane.Services.Interfaces;
using Feane.ViewModels.DiscountedProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DiscountedProductController : Controller
    {
        private readonly IDiscountedProductService _service;
        private readonly AppDbContext _context;

        public DiscountedProductController(IDiscountedProductService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Dishes = await _context.Dishes.ToListAsync();
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DiscountedProductCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Dishes = await _context.Dishes.ToListAsync();
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
            var discountedProductVM = await _service.GetByIdAsync(id);
            if (discountedProductVM == null)
                return NotFound();

            ViewBag.Dishes = await _context.Dishes.ToListAsync();

            return View(discountedProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DiscountedProductUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Dishes = await _context.Dishes.ToListAsync();
                return View(vm);
            }

            await _service.Update(vm);

            return RedirectToAction(nameof(Index));
        }

    }

}

