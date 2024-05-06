
namespace KeyboxWeb.Models;

public sealed record Account(
    int Id,
    int SubcategoryId,
    string Login,
    string? Email,
    string Password,
    DateTime DateAdd,
    DateTime DateUpdate
    //Subcategory Subcategory
);