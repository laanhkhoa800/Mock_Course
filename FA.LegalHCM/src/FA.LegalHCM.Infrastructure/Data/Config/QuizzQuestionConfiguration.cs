using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class QuizzQuestionConfiguration : IEntityTypeConfiguration<QuizzQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizzQuestion> builder)
        {
            builder.ToTable("QuizzQuestion");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(s => s.Title).HasMaxLength(100).IsRequired();
            builder.HasOne<Quizz>(s => s.Quizz)
              .WithMany(g => g.QuizzQuestions)
              .HasForeignKey(x => x.QuizzId);
        }
    }
}
