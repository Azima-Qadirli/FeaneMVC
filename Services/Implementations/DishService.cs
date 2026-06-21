using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Dish;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;

        public DishService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _FolderPath = Path.Combine(_env.WebRootPath, "images");
        }

         public async Task CreateAsync(DishCreateVM vm)
        {
            string uniqueFileName = await vm.Image.FileUploadAsync(_FolderPath);
             Dish dish = new()
            {
                ImageName = uniqueFileName,
                Name = vm.Name,
                DishPrice = vm.DishPrice,
                Description = vm.Description
             };
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if ( dish == null) return;
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DishGetVM>> GetAllAsync()
        {
           return await _context.Dishes.Select(dish => new DishGetVM()
           {
              Id = dish.Id,
              Name = dish.Name,
              ImageName = dish.ImageName,
              Description = dish.Description,
              DishPrice = dish.DishPrice
           }).ToListAsync();
        }

        public async Task <DishUpdateVM> GetByIdAsync(int id)
        {
           var dish = await _context.Dishes.FindAsync(id);
            if (dish is null) return null;
            return new DishUpdateVM()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                DishPrice = dish.DishPrice
            };
        }

        public async Task Update(DishUpdateVM vm)
        {
            var product = await _context.Dishes.FindAsync(vm.Id);
            if (product == null) return;

            if (vm.Image!= null)

            {
                string newImage = await vm.Image.FileUploadAsync(_FolderPath);
                string oldImage = Path.Combine(_FolderPath, product.ImageName);
                ExtensionMethod.DeleteFile(oldImage);
                product.ImageName = newImage;
            }

            product.Name = vm.Name;
            product.DishPrice = vm.DishPrice;
            product.Description = vm.Description;

            _context.Dishes.Update(product);
            await _context.SaveChangesAsync();
        }

        
    }
}
