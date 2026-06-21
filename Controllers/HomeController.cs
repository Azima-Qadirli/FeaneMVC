using Feane.Context;
using Feane.ViewModels.Appaeareance;
using Feane.ViewModels.BookTable;
using Feane.ViewModels.Customers;
using Feane.ViewModels.DiscountedProduct;
using Feane.ViewModels.Dish;
using Feane.ViewModels.Home;
using Feane.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Feane.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM();

            vm.DiscountedProducts = await _context.DiscountedProducts
                .Include(p => p.Dish)
                .Select(p => new DiscountedProductGetVM()
                {
                    Id = p.Id,
                    Percentage = p.Percentage,
                    Name = p.Dish.Name,
                    ImageName = p.Dish.ImageName
                }).ToListAsync();

            vm.Appeareances = await _context.Appeareances.Select(p => new AppeareanceGetVM()
            {
                Description = p.Description,
                Id = p.Id,
                ImageName = $"{p.ImageName}",
                Title = p.Title
            }).ToListAsync();

            vm.BookTable = await _context.BookTables.Select(p => new BookTableGetVM()
            {
                Id = p.Id,
            }).ToListAsync();

            vm.Customers = await _context.Customers.Select(p => new CustomersGetVM()
            {
                Name = p.Name,
                Comment = p.Comment,
                Id = p.Id,
                ImageName = p.ImageName
            }).ToListAsync();

            vm.Dishes = await _context.Dishes.Select(p => new DishGetVM()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DishPrice = p.DishPrice,
                ImageName = p.ImageName
            }).ToListAsync();

            vm.Slider = await _context.Sliders.Select(p => new SliderGetVM()
            {
                Name = p.Name,
                Description = p.Description,
                Id = p.Id
            }).ToListAsync();

            return View(vm);








        }


    }
}
