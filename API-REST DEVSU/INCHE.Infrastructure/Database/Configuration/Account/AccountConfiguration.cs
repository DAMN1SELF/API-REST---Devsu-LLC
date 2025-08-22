using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<AccountEntity> b)
        {
            b.ToTable("Cuenta");


            b.HasKey(e => e.NumeroCuenta);
            b.Property(e => e.NumeroCuenta)
                .HasColumnName("NumeroCuenta")
                .IsRequired();

            b.Property(c => c.SaldoInicial)
                .HasColumnType("decimal(18,2)");

            b.Property(c => c.SaldoActual)
                .HasColumnType("decimal(18,2)");

            b.Property(c => c.Estado)
                .HasDefaultValue(true);

            b.Property(c => c.FechaApertura)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relación 1:N con Cliente
            b.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Cuentas)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Cuenta_Cliente");
        }
    }
}