using Feane.Context;
using Feane.Models;
using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Feane
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Account/Login";

                options.AccessDeniedPath = "/Admin/Account/Login";

                options.Cookie.Name = "FeaneAdminCookie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });

            builder.Services.AddScoped<IAppearanceService, AppearanceService>();
            builder.Services.AddScoped<IBookTableService, BookTableService>();
            builder.Services.AddScoped<ICustomersService, CustomerService>();
            builder.Services.AddScoped<IDiscountedProductService, DiscountedProductService>();
            builder.Services.AddScoped<IDishService, DishService>();
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            var app = builder.Build();

            // Area route
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}