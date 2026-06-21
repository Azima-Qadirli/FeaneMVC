using Feane.Context;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class BookTableService : IBookTableService
    {
        private readonly AppDbContext _context;

        public BookTableService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(BookTableCreateVM vm)
        {
            BookTable bookTable = new()
            {
                 Name = vm.Name,
                 Email = vm.Email,
                 PhoneNumber = vm.PhoneNumber,
                 PersonNumber = vm.PersonNumber,
                 Date = vm.Date.ToUniversalTime()
            };
            await _context.BookTables.AddAsync(bookTable);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var bookTable = await _context.BookTables.FindAsync(id);
            if (bookTable == null) return;
            _context.BookTables.Remove(bookTable);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookTableGetVM>> GetAllAsync()
        {
           return await _context.BookTables.Select(p => new BookTableGetVM ()
           {
               Id = p.Id,
               Name = p.Name,
               Email = p.Email,
               Date =p.Date,
               PersonNumber = p.PersonNumber,
               PhoneNumber = p.PhoneNumber
           }).ToListAsync();
        }

        public async Task <BookTableUpdateVM> GetByIdAsync(int id)
        {
           var table = await _context.BookTables.FindAsync(id);
            if (table is null) return null;

            return new BookTableUpdateVM
            {
              Id = table.Id,
              Date =table.Date,
              Name = table.Name,
              Email = table.Email,
              PersonNumber= table.PersonNumber,
              PhoneNumber = table.PhoneNumber
            };
           
        }

        public async Task Update(BookTableUpdateVM vm)
        {
            var bookTable = await _context.BookTables.FindAsync(vm.Id);
            if (bookTable is null) return;

            bookTable.Name = vm.Name;
            bookTable.Email = vm.Email;
            bookTable.Date = vm.Date.ToUniversalTime();
            bookTable.PhoneNumber = vm.PhoneNumber;
            bookTable.PersonNumber = vm.PersonNumber;

            _context.BookTables.Update(bookTable);
            await _context.SaveChangesAsync();
        }

        
    }
}
