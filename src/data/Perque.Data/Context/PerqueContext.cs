using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Perque.Entities.Infra;
using Perque.Entities.Productivity;
using Perque.Entities.Sales;

namespace Perque.Data.Context
{
    public class PerqueContext : DbContext
    {
        public PerqueContext(DbContextOptions<PerqueContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=PerqueDB;User Id=sa;Password=123");
            }
        }
        #region DbSets
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Supplier> Suplliers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; } 
        #endregion
    }

    public class PerqueContextFactory : IDesignTimeDbContextFactory<PerqueContext>
    {
        public PerqueContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PerqueContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=PerqueDB;User Id=sa;Password=123");

            return new PerqueContext(optionsBuilder.Options);
        }
    }
}
