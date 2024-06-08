using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Models.Entites;

public sealed class Category : IModel
{
    public int Id { get; set; }
    public int VaultId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Vault Vault { get; set; } = new();
    public ICollection<Subcategory> Subcategories { get; set; } = [];
}