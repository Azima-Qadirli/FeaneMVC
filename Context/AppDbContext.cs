using Feane.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Reflection;

namespace Feane.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Appeareance> Appeareances { get; set; }
        public DbSet<BookTable> BookTables { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<DiscountedProduct> DiscountedProducts { get; set; }
        public DbSet<Dish> Dishes { get; set; }

    }

   
}     

