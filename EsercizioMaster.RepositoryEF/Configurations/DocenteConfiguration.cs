using EsercizioMaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioMaster.RepositoryEF
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.ToTable("Docente");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Cognome).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Email).IsRequired().HasMaxLength(20);
            builder.Property(d=>d.NumeroTelefono).IsRequired().HasMaxLength(10);

            //relazione con Lezione
            builder.HasMany(d=>d.Lezioni).WithOne(d=>d.Docente).HasForeignKey(d=>d.DocenteId);
        }
    }
}