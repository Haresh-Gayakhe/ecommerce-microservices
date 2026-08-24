using ECommerce.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly));
            return services;
        }
    }
}
