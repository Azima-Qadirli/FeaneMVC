using Feane.ViewModels.Appaeareance;

namespace Feane.Services.Interfaces
{
    public interface IAppearanceService
    {
        Task<List<AppeareanceGetVM>> GetAllAsync();
        Task<AppaeareanceUpdateVM> GetByIdAsync (int id);
        Task CreateAsync (AppaereanceCreateVM vm);
        Task Update (AppaeareanceUpdateVM vm);
        Task DeleteAsync (int id);
    }
}
