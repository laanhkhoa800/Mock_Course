using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(s => s.IsRead)
                .HasDefaultValue(false);
            builder.Property(s => s.Title).HasMaxLength(250).IsRequired();
            builder.Property(s => s.Detail).HasMaxLength(250).IsRequired();
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Notifications)
               .HasForeignKey(x => x.UserId);
        }
    }
}
