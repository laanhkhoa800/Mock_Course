using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.UserId)
                .IsRequired();
            
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(s => s.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(s => s.OriginPrice)
                .HasColumnType("decimal(5,2)");

            builder.HasOne<Promotion>(s => s.Promotion)
               .WithMany(g => g.Courses)
               .HasForeignKey(x => x.PromotionId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Courses)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<SubCategory>(s => s.SubCategory)
               .WithMany(g => g.Courses)
               .HasForeignKey(x => x.SubCategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Language>(s => s.Language)
               .WithMany(g => g.Courses)
               .HasForeignKey(x => x.LanguageId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
