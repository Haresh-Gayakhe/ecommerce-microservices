using ECommerce.Application.Behaviors;
using FluentValidation;
using MediatR;
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
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
