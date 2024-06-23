using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Models.Entites;

public sealed class Account : IModel
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public string Login { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public DateTime DateAdd { get; set; }
    public DateTime DateUpdate { get; set; }
    public required Card Card { get; set; }
}