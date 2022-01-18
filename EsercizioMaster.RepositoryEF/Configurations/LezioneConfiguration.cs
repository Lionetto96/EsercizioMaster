using EsercizioMaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioMaster.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("Lezione");
            builder.HasKey(l => l.LezioneId);
            builder.Property(l=>l.DataOraInizio).IsRequired();
            builder.Property(l=>l.Aula).IsRequired().HasMaxLength(20);
            builder.Property(l=>l.Durata).IsRequired();
            //relazione con corso e docente
            builder.HasOne(l => l.Corso).WithMany(l => l.Lezioni).HasForeignKey(l => l.Codice).HasConstraintName("FKCodiceCorso");
            builder.HasOne(l => l.Docente).WithMany(l => l.Lezioni).HasForeignKey(l => l.DocenteId).HasConstraintName("FKDocenteId");
        }
    }
}