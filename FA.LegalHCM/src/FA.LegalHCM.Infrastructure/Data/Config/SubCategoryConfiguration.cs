using FA.LegalHCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("SubCategory");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).HasMaxLength(100);
        builder.Property(s => s.Status).HasDefaultValue(false);
        builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        builder.HasOne<Category>(s => s.Category)
        .WithMany(g => g.SubCategories)
        .HasForeignKey(x => x.CategoryId);
    }
}

