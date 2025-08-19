using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Configuration
{
    public class PersonaConfiguration
    {
        public PersonaConfiguration(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(x => x.PersonaId).HasName("PK_Persona");

            builder.Property(x => x.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Genero)
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(x => x.Identificacion)
                .HasMaxLength(20);

            builder.Property(x => x.Direccion).HasMaxLength(200);
            builder.Property(x => x.Telefono).HasMaxLength(20);

            builder.HasIndex(x => x.Identificacion)
                .IsUnique()
                .HasDatabaseName("UX_Persona_Identificacion")
                .HasFilter("[Identificacion] IS NOT NULL");
        }
    }
}