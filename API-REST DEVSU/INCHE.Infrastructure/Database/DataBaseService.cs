using INCHE.Domain.Entities;
using INCHE.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Infrastructure.Database;

public class BancoDbContext : DbContext
{
    public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options) { }

    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Cuenta> Cuentas => Set<Cuenta>();
    public DbSet<Movimiento> Movimientos => Set<Movimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguration(modelBuilder);
    }

    private void EntityConfiguration(ModelBuilder modelBuilder)
    {
        new PersonaConfiguration(modelBuilder.Entity<Persona>());
        new ClienteConfiguration(modelBuilder.Entity<Cliente>());  
        new CuentaConfiguration(modelBuilder.Entity<Cuenta>());
        new MovimientoConfiguration(modelBuilder.Entity<Movimiento>());
    }
}