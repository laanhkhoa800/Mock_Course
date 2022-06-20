using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class QuestionAndAnswerConfiguration : IEntityTypeConfiguration<QuestionAndAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAndAnswer> builder)
        {
            builder.ToTable("QuestionAndAnswer");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(s => s.Comment).HasMaxLength(250).IsRequired();
            builder.HasOne(p => p.QuestionAnswer).WithMany().HasForeignKey(p => p.ParentId);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.QuestionAndAnswers)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Course>(s => s.Course)
               .WithMany(g => g.QuestionAndAnswers)
               .HasForeignKey(x => x.CourseId);
        }
    }
}
