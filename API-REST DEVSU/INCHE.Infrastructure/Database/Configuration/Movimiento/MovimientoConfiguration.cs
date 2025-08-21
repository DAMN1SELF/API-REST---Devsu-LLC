using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class MovimientoConfiguration
    {
        public MovimientoConfiguration(EntityTypeBuilder<MovimientoEntity> e)
        {
            e.ToTable("Movimiento");
            e.HasKey(x => x.MovimientoId).HasName("PK_Movimiento");

            e.Property(x => x.Fecha)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            e.Property(x => x.TipoMovimiento)
                .HasColumnType("char(1)") // 'C' o 'D'
                .IsRequired();

            e.Property(x => x.Valor).HasPrecision(18, 2);
            e.Property(x => x.SaldoDisponible).HasPrecision(18, 2);

            e.HasOne(x => x.Cuenta)
                .WithMany(c => c.Movimientos)
                .HasForeignKey(x => x.NumeroCuenta)
                .HasConstraintName("FK_Movimiento_Cuenta_NumeroCuenta");

            e.HasIndex(x => new { x.NumeroCuenta, x.Fecha })
                .HasDatabaseName("IX_Movimiento_Cuenta_Fecha");
        }
    }
}
