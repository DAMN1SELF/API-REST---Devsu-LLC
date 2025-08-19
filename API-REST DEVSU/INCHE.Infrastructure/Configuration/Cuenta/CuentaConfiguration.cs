using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Configuration
{
    public class CuentaConfiguration
    {
        public CuentaConfiguration(EntityTypeBuilder<Cuenta> e)
        {
            e.ToTable("Cuenta");
            e.HasKey(x => x.NumeroCuenta).HasName("PK_Cuenta");

            e.Property(x => x.NumeroCuenta)
                .HasMaxLength(20)
                .IsUnicode(false);

            e.Property(x => x.TipoCuenta)
                .IsRequired(); 

            e.Property(x => x.SaldoInicial).HasPrecision(18, 2);
            e.Property(x => x.SaldoActual).HasPrecision(18, 2);

            e.Property(x => x.Estado).HasDefaultValue(true);

            e.Property(x => x.FechaApertura)
                .HasDefaultValueSql("CAST(GETUTCDATE() AS date)");

            e.HasOne(x => x.Cliente)
                .WithMany(c => c.Cuentas)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("FK_Cuenta_Cliente_ClienteId");

            e.HasIndex(x => x.ClienteId)
                .HasDatabaseName("IX_Cuenta_ClienteId");
        }
    }
}