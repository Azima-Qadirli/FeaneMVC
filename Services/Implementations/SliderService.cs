using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Feane.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SliderCeateVM vm)
        {
            Slider slider = new()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return; 
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderGetVM>> GetAllAsync()
        {
            return await _context.Sliders.Select(p => new SliderGetVM()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
                
            }).ToListAsync();
            
        }

        public async Task<SliderUpdateVM> GetByIdAsync(int id)
        {
            var product = await _context.Sliders.FindAsync(id);
            if (product is null) return null;

            return new SliderUpdateVM()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
        }

        public async Task Update(SliderUpdateVM vm)
        {
            var product = await _context.Sliders.FindAsync(vm.Id);
            if (product is null) return;

            product.Name = vm.Name;
            product.Description = vm.Description;

            _context.Sliders.Update(product);
            await _context.SaveChangesAsync();

        }

       
    }
}
