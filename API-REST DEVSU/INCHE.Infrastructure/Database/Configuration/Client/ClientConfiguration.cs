using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<ClientEntity> b)


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

            b.HasOne(c => c.Person)
                .WithOne(p => p.Cliente)
                .HasForeignKey<ClientEntity>(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}