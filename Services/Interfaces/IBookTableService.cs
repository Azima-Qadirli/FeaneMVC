using Feane.ViewModels.BookTable;

namespace Feane.Services.Interfaces
{
    public interface IBookTableService
    {
        Task<List<BookTableGetVM>> GetAllAsync();
        Task<BookTableUpdateVM>GetByIdAsync(int id);
        Task CreateAsync(BookTableCreateVM vm);
        Task Update(BookTableUpdateVM vm);
        Task DeleteAsync(int id);
    }
}
