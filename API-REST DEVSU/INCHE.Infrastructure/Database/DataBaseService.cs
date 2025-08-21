using INCHE.Application.DataBase;
using INCHE.Domain.Entities;
using INCHE.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace INCHE.Infrastructure.Database;

public class DataBaseService : DbContext, IDataBaseService
{
    public DataBaseService(DbContextOptions options) : base(options) { }

    public DbSet<ClienteEntity> Cliente { get; set; }
    public DbSet<CuentaEntity> Cuenta { get; set; }
    public DbSet<MovimientoEntity> Movimiento { get; set; }
    public DbSet<PersonaEntity> Persona { get; set; }

    public Task<IDbContextTransaction> BeginTransactionAsync()
        => Database.BeginTransactionAsync();

    public async Task<bool> SaveAsync()
        => await SaveChangesAsync() > 0;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        EntityConfiguration(modelBuilder);
    }

    private void EntityConfiguration(ModelBuilder modelBuilder)
    {
        

        new PersonaConfiguration(modelBuilder.Entity<PersonaEntity>());
        new ClienteConfiguration(modelBuilder.Entity<ClienteEntity>());
        new CuentaConfiguration(modelBuilder.Entity<CuentaEntity>());
        new MovimientoConfiguration(modelBuilder.Entity<MovimientoEntity>());

    }
}