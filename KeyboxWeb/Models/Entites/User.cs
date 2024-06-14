namespace KeyboxWeb.Models.Entites;

public sealed class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordHint { get; set; } = string.Empty;
    public ICollection<Vault> Vaults { get; set; } = [];
}