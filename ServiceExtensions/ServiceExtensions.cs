using Microsoft.EntityFrameworkCore;
using QuarterlySalesApp.Models;
using QuarterlySalesApp.Models.DataLayer.Repositories;

namespace QuarterlySalesApp.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<QuarterlyEmployeeSalesDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), (typeof(Repository<>)));

            return services;
        }
    }
}
