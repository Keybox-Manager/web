using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Models.Configurations;

internal sealed class VaultConfiguration : IEntityTypeConfiguration<Vault>
{
    public void Configure(EntityTypeBuilder<Vault> builder)
    {
        builder.HasMany(x => x.Categories)
            .WithOne(x => x.Vault)
            .HasForeignKey(x => x.VaultId);
    }
}