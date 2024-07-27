using KeyboxWeb.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyboxWeb.Controllers;

public sealed class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    public IActionResult Search(string? name)
    {
        var cards = _cardService.Get(name);
        return PartialView(cards);
    }

    public IActionResult ShowInfo(int id)
    {
        return PartialView(_cardService.Get(id));
    }
}
