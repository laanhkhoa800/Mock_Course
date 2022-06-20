using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class LessonCompletionConfiguration : IEntityTypeConfiguration<LessonCompletion>
    {
        public void Configure(EntityTypeBuilder<LessonCompletion> builder)
        {
            builder.ToTable("LessonCompletion");
            builder.HasKey(s => new { s.LessonId, s.UserId });
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.LessonCompletions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Lesson>(s => s.Lesson)
               .WithMany(g => g.LessonCompletions)
               .HasForeignKey(x => x.LessonId);

        }
    }
}
