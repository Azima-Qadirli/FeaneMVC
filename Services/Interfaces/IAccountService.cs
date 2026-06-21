using Feane.ViewModels.Account;

namespace Feane.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterVM vm);
        Task LoginAsync(LoginVM vm);
        Task Logout();
    }
}
