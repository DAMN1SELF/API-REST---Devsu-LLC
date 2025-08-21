using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<ClienteEntity> b)
        {

            b.ToTable("Cliente");

            // MUY IMPORTANTE:
            // Renombrar la PK heredada (PersonaId) en la tabla Cliente → ClienteId
            b.Property(e => e.PersonaId)
                .HasColumnName("ClienteId");

            b.Property(e => e.ContrasenaHash)
                .HasColumnName("ContrasenaHash")
                .IsRequired();

            b.Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasDefaultValue(true);

            b.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasDefaultValueSql("sysdatetime()");
        }
    }
}