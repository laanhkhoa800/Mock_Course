using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.Property(s => s.Price).HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(s => s.Type).HasDefaultValue("Sales");
            builder.HasKey(orderDetail => new
            {
                orderDetail.CourseId,
                orderDetail.UserId
            });
            builder.HasOne<Course>(s => s.Course)
               .WithMany(g => g.OrderDetails)
               .HasForeignKey(x => x.CourseId);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.OrderDetails)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
