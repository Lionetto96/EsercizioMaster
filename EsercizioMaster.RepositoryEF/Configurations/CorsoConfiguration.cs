using EsercizioMaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioMaster.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
            builder.ToTable("Corso");
            builder.HasKey(c=>c.Codice);
            builder.Property(c=>c.Nome).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Descrizione).IsRequired().HasMaxLength(50);

            //relazione con studenti e lezione
            builder.HasMany(c=>c.Studenti).WithOne(c=>c.Corso).HasForeignKey(c=>c.Codice);
            builder.HasMany(c => c.Lezioni).WithOne(c => c.Corso).HasForeignKey(c => c.Codice);
        }
    }
}