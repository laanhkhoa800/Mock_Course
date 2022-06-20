using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class UserQuizzAnswerConfiguration : IEntityTypeConfiguration<UserQuizzAnswer>
    {
        public void Configure(EntityTypeBuilder<UserQuizzAnswer> builder)
        {
            builder.ToTable("UserQuizzAnswer");
            builder.HasKey(userQuizzAnswer => new
            {
                userQuizzAnswer.UserId,
                userQuizzAnswer.QuizzAnswerId
            });
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.UserQuizzAnswers)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<QuizzAnswer>(s => s.QuizzAnswer)
               .WithMany(g => g.UserQuizzAnswers)
               .HasForeignKey(x => x.QuizzAnswerId);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
