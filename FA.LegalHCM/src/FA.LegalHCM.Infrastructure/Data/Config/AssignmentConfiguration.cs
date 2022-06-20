using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).HasMaxLength(100);
            builder.Property(s => s.Content).HasMaxLength(250);
            builder.HasOne<Section>(s => s.Section)
               .WithMany(g => g.Assignments)
               .HasForeignKey(x => x.SectionId);
        }
    }
}
