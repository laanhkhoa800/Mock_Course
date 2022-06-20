using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachment");
            builder.HasKey(s => s.Id);
            builder.HasOne<Assignment>(s => s.Assignment)
               .WithMany(g => g.Attachments)
               .HasForeignKey(x => x.AssignmentId);
        }
    }
}
