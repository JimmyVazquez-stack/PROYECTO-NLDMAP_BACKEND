using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLDMAP.Domain.Interfaces;
using NLDMAP.Infrastructure.ExternalServices;
using NLDMAP.Infrastructure.Persistence;
using NLDMAP.Infrastructure.Repositories;


namespace NLDMAP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //modulo 1 : Identidad y seguridad 
            services.AddPersistenceInfrastructure(configuration);
            
            //modulo 2 : Documentos y caracteristicas 
            // services.AddMongoDbPersistence(configuration);
            
            //Modulo 3: Grafos
            //services.AddNeo4jPersistence(configuration);
            
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IExternalAuthValidator, GoogleAuthValidator>();
        
            return services;
        }
    }
}