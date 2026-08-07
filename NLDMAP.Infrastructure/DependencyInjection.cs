using NLDMAP.Domain.Interfaces;
using NLDMAP.Infrastructure.ExternalServices;
using NLDMAP.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NLDMAP.Infrastructure
{
    public class DependencyInjection
    {
        services.AddScoped<IUsuarioRepository, EfUsuarioRepository>();
        services.AddScoped<IExternalAuthValidator, GoogleAuthVlidator>();
        
        return services;
    }
}