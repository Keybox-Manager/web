using KeyboxWeb.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyboxWeb.Controllers;

public sealed class CardController : Controller
{
    private readonly ICardService _cardService;
    private readonly ICategoryService _categoryService;

    public CardController(ICardService cardService, ICategoryService categoryService)
    {
        _cardService = cardService;
        _categoryService = categoryService;
    }
    public IActionResult Index(int categoryId)
    {
        var category = _categoryService.Get(categoryId);
        return PartialView(category.Cards);
    }

    public IActionResult Search(string? name)
    {
        var cards = _cardService.Get(name);
        return PartialView(nameof(Index), cards);
    }

    public IActionResult ShowInfo(int id)
    {
        return PartialView(_cardService.Get(id));
    }
}
