using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuarterlySalesApp.Models.DomainModels;

namespace QuarterlySalesApp.Models.DataLayer.SeedData
{
    public class SeedSales : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.Property(e => e.Id).IsRequired();
            entity.Property(e => e.Amount).HasColumnType("decimal");

            entity.HasData(
                new Sale { Id = 1, Quarter = 1, Year = 2024, Amount = 15000, EmployeeId = 1 },
                new Sale { Id = 2, Quarter = 3, Year = 2024, Amount = 18000, EmployeeId = 2 },
                new Sale { Id = 3, Quarter = 2, Year = 2024, Amount = 20000, EmployeeId = 3 },
                new Sale { Id = 4, Quarter = 1, Year = 2024, Amount = 16000, EmployeeId = 4 },
                new Sale { Id = 5, Quarter = 2, Year = 2024, Amount = 22000, EmployeeId = 5 },
                new Sale { Id = 6, Quarter = 1, Year = 2024, Amount = 19000, EmployeeId = 6 }
            );
        }
    }
}
