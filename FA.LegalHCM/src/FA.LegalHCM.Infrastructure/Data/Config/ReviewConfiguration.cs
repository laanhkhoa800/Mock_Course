using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("ReView");
            builder.Property(s => s.Content).IsRequired();
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Reviews)
               .HasForeignKey(x => x.UserId);
            builder.HasOne<Enrollment>(s => s.Enrollment)
             .WithMany(g => g.Reviews)
             .HasForeignKey(x => x.EnrollmentId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
