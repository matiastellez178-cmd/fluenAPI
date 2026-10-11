using HeroesMvc.Data.Configurations;
using HeroesMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesMvc.Data;

public class HeroesDbContext : DbContext
{
    public HeroesDbContext(DbContextOptions<HeroesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ciudad> Ciudades => Set<Ciudad>();
    public DbSet<Villano> Villanos => Set<Villano>();
    public DbSet<Cuartel> Cuarteles => Set<Cuartel>();
    public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Registro de configuraciones de la práctica (Clase 02)
        modelBuilder.ApplyConfiguration(new CiudadConfiguration());
        modelBuilder.ApplyConfiguration(new VillanoConfiguration());

        // Registro de configuraciones del ejercicio (Cuarteles y Vehículos)
        modelBuilder.ApplyConfiguration(new CuartelConfiguration());
        modelBuilder.ApplyConfiguration(new VehiculoConfiguration());

        // Nota: Si se desea registrar automáticamente todas las configuraciones del ensamblado:
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(HeroesDbContext).Assembly);
    }
}
