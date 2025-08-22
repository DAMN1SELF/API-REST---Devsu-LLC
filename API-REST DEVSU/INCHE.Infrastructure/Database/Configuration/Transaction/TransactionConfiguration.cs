using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class TransactionConfiguration
    {
        public TransactionConfiguration(EntityTypeBuilder<TransactionEntity> b)
        {
            b.ToTable("Movimiento");

            b.HasKey(m => m.MovimientoId);
            b.Property(m => m.MovimientoId)
                .HasColumnName("MovimientoId")
                .HasColumnType("bigint")               
                .ValueGeneratedOnAdd();


            b.Property(m => m.NumeroCuenta)
                .HasColumnName("NumeroCuenta");

            b.Property(m => m.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime2(0)")
                .HasDefaultValueSql("sysdatetime()");

            b.Property(m => m.TipoMovimiento)
                .HasColumnName("TipoMovimiento")
                .IsRequired();

            b.Property(m => m.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(18,2)");

            b.Property(m => m.SaldoDisponible)
                .HasColumnName("SaldoDisponible")
                .HasColumnType("decimal(18,2)");

            b.HasOne(m => m.Cuenta)
                .WithMany(c => c.Movimientos)
                .HasForeignKey(m => m.NumeroCuenta)
                .HasPrincipalKey(c => c.NumeroCuenta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Movimiento_Cuenta");
        }
    }
}