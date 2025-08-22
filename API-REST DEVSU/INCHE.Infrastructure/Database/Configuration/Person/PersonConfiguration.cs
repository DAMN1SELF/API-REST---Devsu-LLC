using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace INCHE.Infrastructure.Database.Configuration
{
    public class PersonConfiguration
    {
        public PersonConfiguration(EntityTypeBuilder<PersonaEntity> b)
        {

            b.ToTable("Persona");

            b.HasKey(p => p.PersonaId);

            b.Property(p => p.PersonaId)
                .ValueGeneratedOnAdd();

            b.Property(p => p.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            b.Property(p => p.Genero)
                .HasMaxLength(1);

            b.Property(p => p.Identificacion)
                .HasMaxLength(30);

            b.Property(p => p.Direccion)
                .HasMaxLength(200);

            b.Property(p => p.Telefono)
                .HasMaxLength(20);
        }
    }
}
