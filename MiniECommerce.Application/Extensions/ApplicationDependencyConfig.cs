using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Repositories;
using MiniECommerce.Domain.Repositories;

namespace MiniECommerce.Application.Extensions
{
    public static class ApplicationDependencyConfig
    {
        /// <summary>
        /// Application katmanında kullanılan dependency ler
        /// </summary>
        public static IServiceCollection AddApplicationDependecyConfig(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
