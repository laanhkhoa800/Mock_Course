using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class DiscussionConfiguration : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.ToTable("Discussion");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Comment).HasMaxLength(250).IsRequired();
            builder.Property(x => x.DisLike).HasDefaultValue(0);
            builder.Property(x => x.Like).HasDefaultValue(0);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Discussions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<User>(s => s.Sender)
               .WithMany(g => g.DiscussionSenders)
               .HasForeignKey(x => x.SenderId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
