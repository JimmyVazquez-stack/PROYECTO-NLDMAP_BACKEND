using Microsoft.EntityFrameworkCore;
using NLDMAP.Domain.Entities;

namespace NLDMAP.Infrastructure.Persistence
{
    public class NldmapDbContext : DbContext
    {
        //Constructor para la inyeccion de dependencias
        public NldmapDbContext(DbContextOptions<NldmapDbContext> options) : base(options)
        {
        }

        //Definicion de tablas en la BD
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }

        //Configuracion de las tablas - fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configuracion en la tabla usuarios
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                //Hacer que el Email unico
                entity.HasIndex(e => e.Email).IsUnique();
            });

            //Configuracion de tabla de reportes
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Id);

                //Mapeo del value object 'Coordenada' para que sus propiedades
                //esten dentro de la misma tabla reportes
                entity.OwnsOne(e => e.LastSightingLocation, loc =>
                {
                    loc.Property(c => c.Latitude).HasColumnName("Latitude");
                    loc.Property(c => c.Longitude).HasColumnName("Longitude");
                });
            });
        }
    }
}