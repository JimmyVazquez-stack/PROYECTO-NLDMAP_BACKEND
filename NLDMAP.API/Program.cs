using NLDMAP.Application;
using NLDMAP.Infrastructure;
using NLDMAP.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 1. Inyección de la infraestructura (Base de datos)
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// 2. Endpoint de prueba rápida
app.MapGet("/", () => "¡La API está corriendo y la Infraestructura se inyectó correctamente!");

app.Run();