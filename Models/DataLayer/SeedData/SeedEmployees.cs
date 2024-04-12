using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuarterlySalesApp.Models.DomainModels;

namespace QuarterlySalesApp.Models.DataLayer.SeedData
{
    public class SeedEmployees : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.Property(e => e.Id).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100);

            entity.HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 5, 15), DateOfHire = new DateTime(2015, 3, 10), ManagerId = null },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 9, 20), DateOfHire = new DateTime(2017, 7, 22), ManagerId = 1 },
                new Employee { Id = 3, FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateTime(1988, 11, 8), DateOfHire = new DateTime(2016, 9, 5), ManagerId = 1 },
                new Employee { Id = 4, FirstName = "Emily", LastName = "Williams", DateOfBirth = new DateTime(1992, 4, 25), DateOfHire = new DateTime(2018, 2, 14), ManagerId = 1 },
                new Employee { Id = 5, FirstName = "David", LastName = "Brown", DateOfBirth = new DateTime(1983, 12, 12), DateOfHire = new DateTime(2019, 11, 30), ManagerId = 1 },
                new Employee { Id = 6, FirstName = "Sarah", LastName = "Jones", DateOfBirth = new DateTime(1995, 8, 3), DateOfHire = new DateTime(2020, 6, 17), ManagerId = 1 }
            );
        }
    }
}
