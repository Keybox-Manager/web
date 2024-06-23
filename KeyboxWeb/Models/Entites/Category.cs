using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Models.Entites;

public sealed class Category : IModel
{
    public int Id { get; set; }
    public int VaultId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public required Vault Vault { get; set; }
    public ICollection<Card> Cards { get; set; } = [];
}