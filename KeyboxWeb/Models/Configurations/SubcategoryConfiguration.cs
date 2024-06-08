using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Models.Configurations;

internal sealed class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
{
    public void Configure(EntityTypeBuilder<Subcategory> builder)
    {
        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Subcategory)
            .HasForeignKey(x => x.SubcategoryId);
    }
}