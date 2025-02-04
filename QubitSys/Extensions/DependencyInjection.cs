using Microsoft.EntityFrameworkCore;
using QubitSys.Data;
using QubitSys.Persistence;
using QubitSys.Persistence.Contracts;

namespace QubitSys.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
        public static IServiceCollection AddContracts(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }
    }
}
