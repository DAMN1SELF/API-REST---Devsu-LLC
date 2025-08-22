using INCHE.Application.DataBase;
using INCHE.Domain.Entities;
using INCHE.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace INCHE.Infrastructure.Database;

public class DataBaseService : DbContext, IDataBaseService
{
    public DataBaseService(DbContextOptions options) : base(options) { }

    public DbSet<ClientEntity> Cliente { get; set; }
    public DbSet<AccountEntity> Cuenta { get; set; }
    public DbSet<TransactionEntity> Movimiento { get; set; }
    public DbSet<PersonEntity> Persona { get; set; }

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
        new PersonConfiguration(modelBuilder.Entity<PersonEntity>());
        new ClientConfiguration(modelBuilder.Entity<ClientEntity>());
        new AccountConfiguration(modelBuilder.Entity<AccountEntity>());
        new TransactionConfiguration(modelBuilder.Entity<TransactionEntity>());

    }
}