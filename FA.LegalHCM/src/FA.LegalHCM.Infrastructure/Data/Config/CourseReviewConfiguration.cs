using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class CourseReviewConfiguration : IEntityTypeConfiguration<CourseReview>
    {
        public void Configure(EntityTypeBuilder<CourseReview> builder)
        {
            builder.ToTable("CourseReview");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Content).HasMaxLength(250).IsRequired();
            builder.HasOne<Enrollment>(s => s.Enrollment)
               .WithMany(g => g.CourseReviews)
               .HasForeignKey(x => x.EnrollmentId);
        }
    }
}
