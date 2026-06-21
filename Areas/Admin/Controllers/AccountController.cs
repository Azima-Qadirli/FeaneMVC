using Feane.Models;
using Feane.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Appearance");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Email) ?? await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(model);
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            var isSuperAdmin = await _userManager.IsInRoleAsync(user, "SuperAdmin");

            if (!isAdmin && !isSuperAdmin)
            {
                ModelState.AddModelError("", "You don't have access to admin panel");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is incorrect!");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddRole()
        {
            string[] roles = { "Admin", "User", "SuperAdmin" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
            return Json("Rolları uğurla bazaya yazdıq! İndi AddAdmin linkinə keçə bilərsən.");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddAdmin()
        {
            string adminEmail = "admin@feane.com";
            var existingUser = await _userManager.FindByEmailAsync(adminEmail);
            if (existingUser != null) return Json("Admin is already exist in database!");

            var user = new AppUser()
            {
                Email = adminEmail,
                UserName = "AdminUser",
                EmailConfirmed = true,

                FullName = "Azima Qadirli"
            };

            var result = await _userManager.CreateAsync(user, "AdminPassword123!");

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, new string[] { "Admin", "SuperAdmin" });
                return Json("Admin uğurla yaradıldı və rolları təyin olundu! İndi rahatca Login ola bilərsən.");
            }

            return Json(result.Errors);
        }
    }
}