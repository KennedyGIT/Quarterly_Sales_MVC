using Microsoft.EntityFrameworkCore;
using QuarterlySalesApp.Models.DataLayer.SeedData;
using QuarterlySalesApp.Models.DomainModels;

namespace QuarterlySalesApp.Models
{
    public class QuarterlyEmployeeSalesDbContext : DbContext
    {
        public QuarterlyEmployeeSalesDbContext(DbContextOptions<QuarterlyEmployeeSalesDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SeedEmployees());
            modelBuilder.ApplyConfiguration(new SeedSales());
        }
    }
}
