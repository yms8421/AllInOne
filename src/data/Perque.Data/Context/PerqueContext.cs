using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Perque.Contracts;
using Perque.Entities.Infra;
using Perque.Entities.Productivity;
using Perque.Entities.Sales;

namespace Perque.Data.Context
{
    public class PerqueContext : DbContext
    {
        private readonly AppSettings settings;
        public PerqueContext(IOptions<AppSettings> options)
        {
            settings = options.Value;
        }
        public PerqueContext(DbContextOptions<PerqueContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(settings.ConnectionStrings.MainDatabase);
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
        public virtual DbSet<LookUp> Lookups { get; set; } 
        public virtual DbSet<LookUpType> LookUpTypes { get; set; } 
        #endregion
    }
}
