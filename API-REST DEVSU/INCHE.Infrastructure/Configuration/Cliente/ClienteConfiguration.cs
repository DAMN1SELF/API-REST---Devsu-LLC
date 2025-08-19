using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Configuration
{
    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<Cliente> e)
        {
            e.ToTable("Cliente");

            e.HasBaseType<Persona>();

            e.Property(x => x.ContrasenaHash)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(255);

            e.Property(x => x.Estado)
                .HasDefaultValue(true);

            e.Property(x => x.FechaRegistro)
                .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}