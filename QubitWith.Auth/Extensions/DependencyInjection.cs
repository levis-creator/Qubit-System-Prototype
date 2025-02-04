
using QubitSystem.Persistence;
using QubitWith.Auth.Data.Persistence;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddContracts(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();    
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            return services;
        }
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddBlazorBootstrap();
            return services;
        }


    }
}
