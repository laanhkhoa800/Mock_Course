using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(subcription => new
            {
                subcription.UserId,
                subcription.SubscriberId
            });
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Subscriptions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<User>(s => s.Subscriper)
               .WithMany(g => g.Subscripers)
               .HasForeignKey(x => x.SubscriberId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
