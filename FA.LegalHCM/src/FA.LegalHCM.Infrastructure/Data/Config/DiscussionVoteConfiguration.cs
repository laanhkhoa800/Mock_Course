using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class DiscussionVoteConfiguration : IEntityTypeConfiguration<DiscussionVote>
    {
        public void Configure(EntityTypeBuilder<DiscussionVote> builder)
        {
            builder.ToTable("DiscussionVote");
            builder.HasKey(x => new { x.UserId, x.DiscussionId });

            builder.HasOne<Discussion>(s => s.Discussion)
               .WithMany(g => g.DiscussionVotes)
               .HasForeignKey(x => x.DiscussionId);

            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.DiscussionVotes)
               .HasForeignKey(x => x.UserId);
        }
    }
}
