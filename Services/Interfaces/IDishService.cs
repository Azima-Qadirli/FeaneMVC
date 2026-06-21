using Feane.ViewModels.Dish;

namespace Feane.Services.Interfaces
{
    public interface IDishService
    { 
        Task<List<DishGetVM>>GetAllAsync();
        Task <DishUpdateVM>GetByIdAsync(int id);
        Task CreateAsync(DishCreateVM vm);
        Task Update(DishUpdateVM vm);
        Task DeleteAsync(int id);
       
    }
}
