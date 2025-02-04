using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QubitSystem.Data;
using QubitSystem.Models.Common;
using QubitSystem.Persistence;
using QubitSystem.Persistence.Contracts;

namespace QubitSystem.Extensions
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
            services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {
            services.AddBlazorise(options => options.Immediate = true)
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            return services;
        }
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                 .AddEntityFrameworkStores<DataDbContext>()
                 .AddDefaultTokenProviders();

            return services;
        }
    }
}
