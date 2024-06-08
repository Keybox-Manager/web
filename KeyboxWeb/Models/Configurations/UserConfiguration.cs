using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Models.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.Vaults)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}