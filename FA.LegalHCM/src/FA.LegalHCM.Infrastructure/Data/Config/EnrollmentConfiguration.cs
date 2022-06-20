using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasKey(s => s.Id);
            builder.HasOne<Course>(s => s.Course)
               .WithMany(g => g.Enrollments)
               .HasForeignKey(x => x.CourseId);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Enrollments)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
