using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Models.Configurations;

internal sealed class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Card)
            .HasForeignKey(x => x.CardId);
    }
}