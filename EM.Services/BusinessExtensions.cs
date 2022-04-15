using EM.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Services
{
    public static class BusinessExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            return services;
        }
    }
}
