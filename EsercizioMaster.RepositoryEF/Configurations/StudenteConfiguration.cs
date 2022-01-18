using EsercizioMaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioMaster.RepositoryEF
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
            builder.ToTable("Studente");
            builder.HasKey(s=>s.Id);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Cognome).IsRequired().HasMaxLength(20);
            builder.Property(s=>s.Email).IsRequired().HasMaxLength(20);
            builder.Property(s => s.DataNascita).IsRequired();
            builder.Property(s=>s.TitoloStudio).IsRequired().HasMaxLength(30);

            //relazione con Corso
            builder.HasOne(s => s.Corso).WithMany(s => s.Studenti).HasForeignKey(s => s.Codice).HasConstraintName("FKCodice");
        }
    }
}