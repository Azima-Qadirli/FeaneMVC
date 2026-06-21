using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class CustomerService : ICustomersService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;

        public CustomerService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _FolderPath = Path.Combine(_env.WebRootPath, "images");
        }

        public async Task CreateAsync(CustomersCreateVM vm)
        {
            string uniqueFileName = await vm.ImageName.FileUploadAsync(_FolderPath);
            Customers customers = new()
            {
                Comment = vm.Comment,
                ImageName = uniqueFileName,
                Name = vm.Name
            };
            await _context.Customers.AddAsync(customers);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }

        public async Task<List<CustomersGetVM>> GetAllAsync()
        {
            return await _context.Customers.Select(p => new CustomersGetVM()
            {
                Name = p.Name,
                ImageName = p.ImageName,
                Comment = p.Comment,
                Id = p.Id
            }).ToListAsync();
        }

        public async Task<CustomersUpdateVM> GetByIdAsync(int id)
        {
            var product = await _context.Customers.FindAsync(id);
            if (product is null) return null;

            return new CustomersUpdateVM
            {
                Comment = product.Comment,
                Id = product.Id,
                Name = product.Name,
            };

        }

        public async Task Update(CustomersUpdateVM vm)
        {
            var customer = await _context.Customers.FindAsync(vm.Id);
            if (customer is null) return;

            if (vm.ImageName != null)
            {
                string newImage = await vm.ImageName.FileUploadAsync(_FolderPath);
                string oldImage = Path.Combine(_FolderPath, customer.ImageName);
                ExtensionMethod.DeleteFile(oldImage);
                customer.ImageName = oldImage;

            }
            customer.Name = vm.Name;
            customer.Comment = vm.Comment;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
        
