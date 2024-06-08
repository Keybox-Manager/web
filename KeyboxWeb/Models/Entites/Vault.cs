using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Models.Entites;

public sealed class Vault : IModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public User User { get; set; } = new();
    public ICollection<Category> Categories { get; set; } = [];
}