using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace Feane.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegisterAsync(RegisterVM vm)
        {
            AppUser user = new AppUser
            {
                UserName = vm.UserName,
                FullName = vm.FullName,
                Email = vm.Email
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Description + " ";
                }
                throw new Exception(errors);
            }
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task LoginAsync(LoginVM vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user is null)
            {
                throw new Exception("Email or password is incorrect.");
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, true);
            if (!result.Succeeded)
            {
                throw new Exception("Email or password is incorrect.");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}