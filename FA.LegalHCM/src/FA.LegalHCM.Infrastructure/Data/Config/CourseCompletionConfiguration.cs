using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class CourseCompletionConfiguration : IEntityTypeConfiguration<CourseCompletion>
    {
        public void Configure(EntityTypeBuilder<CourseCompletion> builder)
        {
            builder.ToTable("CourseCompletion");
            builder.HasKey(courseCompletion => new
            {
                courseCompletion.CourseId,
                courseCompletion.UserId
            });
            builder.HasOne<Course>(s => s.Course)
               .WithMany(g => g.CourseCompletions)
               .HasForeignKey(x => x.CourseId);
            builder.HasOne<User>(s => s.User)
                .WithMany(g => g.CourseCompletions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
