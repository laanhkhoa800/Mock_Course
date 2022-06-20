using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class FavoritedCourseConfiguration : IEntityTypeConfiguration<FavoritedCourse>
    {
        public void Configure(EntityTypeBuilder<FavoritedCourse> builder)
        {
            builder.ToTable("FavoritedCourse");
            builder.HasKey(favoritedCourse => new
            {
                favoritedCourse.CourseId,
                favoritedCourse.UserId
            });
            builder.HasOne<Course>(s => s.Course)
               .WithMany(g => g.FavoritedCourses)
               .HasForeignKey(x => x.CourseId);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.FavoritedCourses)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
