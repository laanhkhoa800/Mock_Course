using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(s => s.Id);
            builder.HasOne<Course>(s => s.Course)
              .WithMany(g => g.ShoppingCarts)
              .HasForeignKey(x => x.CourseId);
            builder.HasOne<User>(s => s.User)
              .WithMany(g => g.ShoppingCarts)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.NoAction);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
