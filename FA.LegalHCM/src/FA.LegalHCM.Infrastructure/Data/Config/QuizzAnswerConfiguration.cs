using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class QuizzAnswerConfiguration : IEntityTypeConfiguration<QuizzAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizzAnswer> builder)
        {
            builder.ToTable("QuizzAnswer");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(s => s.ResultDescription).HasMaxLength(250).IsRequired();
            builder.Property(s => s.Content).HasMaxLength(250).IsRequired();
            builder.HasOne<QuizzQuestion>(s => s.QuizzQuestion)
               .WithMany(g => g.QuizzAnswers)
               .HasForeignKey(x => x.QuestionId);
        }
    }
}
