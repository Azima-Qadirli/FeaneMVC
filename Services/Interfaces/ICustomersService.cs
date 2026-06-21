using Feane.ViewModels.Customers;

namespace Feane.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<List<CustomersGetVM>> GetAllAsync();
        Task <CustomersUpdateVM> GetByIdAsync(int id);
        Task CreateAsync(CustomersCreateVM vm);
        Task Update(CustomersUpdateVM vm);
        Task DeleteAsync(int id);
    }
}
