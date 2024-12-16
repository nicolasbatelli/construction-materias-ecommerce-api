using ConstructionMaterials.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConstructionMaterials.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}