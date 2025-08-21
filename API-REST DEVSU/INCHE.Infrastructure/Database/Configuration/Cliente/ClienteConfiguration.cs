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

            b.HasKey(c => c.ClienteId);

            b.Property(c => c.ContrasenaHash)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(c => c.Estado)
                .HasDefaultValue(true);

            b.Property(c => c.FechaRegistro)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relación 1:1 con Persona (PK = FK)
            b.HasOne(c => c.Persona)
                .WithOne(p => p.Cliente)
                .HasForeignKey<ClienteEntity>(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}