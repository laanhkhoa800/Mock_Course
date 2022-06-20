using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(s => s.Title).HasMaxLength(100).IsRequired();
            builder.Property(s => s.VideoUrl).IsRequired();

            builder.HasOne<Section>(s => s.Section)
               .WithMany(g => g.Lessons)
               .HasForeignKey(x => x.SectionId);
        }
    }
}
