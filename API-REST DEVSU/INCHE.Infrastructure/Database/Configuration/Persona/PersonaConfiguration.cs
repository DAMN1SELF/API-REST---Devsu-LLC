using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class PersonaConfiguration
    {
        public PersonaConfiguration(EntityTypeBuilder<PersonaEntity> b)
        {
            b.ToTable("Persona");

            b.HasKey(x => x.PersonaId);
            b.Property(x => x.PersonaId).HasColumnName("PersonaId");

            b.Property(x => x.Nombres).HasColumnName("Nombres")
                .IsRequired().HasMaxLength(100);

            b.Property(x => x.Genero).HasColumnName("Genero")
                .HasColumnType("char(1)");

            b.Property(x => x.Edad).HasColumnName("Edad");

            b.Property(x => x.Identificacion).HasColumnName("Identificacion")
                .HasMaxLength(20);

            b.Property(x => x.Direccion).HasColumnName("Direccion")
                .HasMaxLength(200);

            b.Property(x => x.Telefono).HasColumnName("Telefono")
                .HasMaxLength(20);
        }
    }
}