using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.Feedbacks)
               .HasForeignKey(x => x.UserId);
        }
    }
}
