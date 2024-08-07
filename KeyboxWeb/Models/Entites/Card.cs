﻿namespace KeyboxWeb.Models.Entites;

public sealed class Card
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Url { get; set; }
    public string? Notes { get; set; }
    public string? Icon { get; set; }
    public required Category Category { get; set; }
    public ICollection<Account> Accounts { get; set; } = [];
}