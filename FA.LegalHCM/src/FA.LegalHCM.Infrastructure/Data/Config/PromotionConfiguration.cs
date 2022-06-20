using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotion");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.DiscountPercent).HasColumnType("decimal(5,2)");
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Promotions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
