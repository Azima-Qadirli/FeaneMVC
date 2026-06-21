using Feane.ViewModels.Appaeareance.cs;

namespace Feane.Services.Interfaces
{
    public interface IBokkTableService
    {
        Task<List<AppaeareanceGetVM>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(AppaereanceCreateVM vm);
        Task Update(AppaeareanceUpdateVM vm);
        Task Update(int id);
        Task DeleteAsync(int id);
    }
}
