using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");             
            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
            builder.Property(s => s.IsStatus).IsRequired().HasDefaultValue(true);
            builder.Property(s => s.AvailableAmount).HasDefaultValue(0);
            builder.Property(s => s.Avatar)
               .HasColumnType("nvarchar(max)")
              .HasDefaultValue(null);
            builder.Property(s => s.AvailableAmount).HasDefaultValue(0);
            builder.HasOne<Role>(s => s.Role)
               .WithMany(g => g.Users)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
