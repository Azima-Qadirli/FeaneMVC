using Feane.Context;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.DiscountedProduct;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class DiscountedProductService : IDiscountedProductService
    {
        private readonly AppDbContext _context;

        public DiscountedProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DiscountedProductCreateVM vm)
        {
            DiscountedProduct discountedProduct = new()
            {
                DishId = vm.DishId,
                Percentage = vm.Percentage
            };
            await _context.DiscountedProducts.AddAsync(discountedProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discountedproduct = await _context.DiscountedProducts.FindAsync(id);
            if (discountedproduct == null) return;
            _context.DiscountedProducts.Remove(discountedproduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DiscountedProductGetVM>> GetAllAsync()
        {
            return await _context.DiscountedProducts
                .Include(p => p.Dish)
                .Select(p => new DiscountedProductGetVM()
                {
                    Id = p.Id,
                    Percentage = p.Percentage,
                    Name = p.Dish.Name,
                    ImageName = p.Dish.ImageName
                }).ToListAsync();
        }

        public async Task<DiscountedProductUpdateVM> GetByIdAsync(int id)
        {
            var product = await _context.DiscountedProducts.FindAsync(id);
            if (product == null) return null;

            return new DiscountedProductUpdateVM
            {
                Id = product.Id,
                Percentage = product.Percentage,
                DishId = product.DishId
            };
        }

        public async Task Update(DiscountedProductUpdateVM vm)
        {
            var product = await _context.DiscountedProducts.FindAsync(vm.Id);
            if (product is null) return;

            product.Percentage = vm.Percentage;
            product.DishId = vm.DishId;

            _context.DiscountedProducts.Update(product);
            await _context.SaveChangesAsync();



        }
    }
}
