using Microsoft.Extensions.DependencyInjection;
using NLDMAP.Domain.Interfaces;
using NLDMAP.Infrastructure.ExternalServices;
using NLDMAP.Infrastructure.Repositories;


namespace NLDMAP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IExternalAuthValidator, GoogleAuthVlidator>();
        
            return services;
        }
    }
}