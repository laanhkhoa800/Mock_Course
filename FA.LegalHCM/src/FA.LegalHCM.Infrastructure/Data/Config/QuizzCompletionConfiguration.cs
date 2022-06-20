using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.LegalHCM.Infrastructure.Data.Config
{
    public class QuizzCompletionConfiguration : IEntityTypeConfiguration<QuizzCompletion>
    {
        public void Configure(EntityTypeBuilder<QuizzCompletion> builder)
        {
            builder.ToTable("QuizzCompletion");
            builder.HasKey(quizzCompletion => new
            {
                quizzCompletion.QuizzId,
                quizzCompletion.UserId
            });
            builder.HasOne<Quizz>(s => s.Quizz)
               .WithMany(g => g.QuizzCompletions)
               .HasForeignKey(x => x.QuizzId);
            builder.HasOne<User>(s => s.User)
               .WithMany(g => g.QuizzCompletions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
