using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Models.Entites;

public sealed class User : IModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordHint { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Vault> Vaults { get; set; } = [];
}