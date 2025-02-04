using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QubitSystemPrototype1.Data.Persistence;
using QubitSystemPrototype1.Data.Persistence.Contracts;

namespace QubitSystemPrototype1.Extensions
{
    public static class DependencyInjection
    {
      
        public static IServiceCollection AddContracts(this IServiceCollection services)
        {
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<ICourseRepository, CourseRepository>();
            //services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {
            services.AddBlazorise(options => options.Immediate = true)
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            return services;
        }
       
    }
}
