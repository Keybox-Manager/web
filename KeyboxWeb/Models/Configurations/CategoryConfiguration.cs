using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Models.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(x => x.Cards)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}