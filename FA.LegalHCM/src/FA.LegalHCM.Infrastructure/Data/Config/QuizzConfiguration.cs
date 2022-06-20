using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class QuizzConfiguration : IEntityTypeConfiguration<Quizz>
    {
        public void Configure(EntityTypeBuilder<Quizz> builder)
        {
            builder.ToTable("Quizz");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(s => s.PercentComplete)
                .HasColumnType("decimal(5,2)");
            builder.Property(s => s.Title).HasMaxLength(100).IsRequired();
            builder.HasOne<Section>(s => s.Section)
               .WithMany(g => g.Quizzes)
               .HasForeignKey(x => x.SectionId);
        }
    }
}
