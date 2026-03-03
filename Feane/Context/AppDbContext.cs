using Feane.Models;
using Microsoft.EntityFrameworkCore;

namespace Feane.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<DiscountedProduct> DiscountedProducts { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
