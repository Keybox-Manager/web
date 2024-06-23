using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Logic.Interfaces.Services;

namespace KeyboxWeb.Controllers;


public class VaultController : Controller
{
    private readonly ICardService _cardService;
    public VaultController(ICardService cardService)
    {
        _cardService = cardService;
    }

    public IActionResult Index()
    {
        var cards = _cardService.Get();
        return View(cards);
    }

    public IActionResult DeleteCard(int id)
    {
        _cardService.Delete(id);
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public IActionResult ChangeCard(int id)
    {
        var card = _cardService.Get(id);
        return View(card);
    }

    [HttpPost]
    public IActionResult ChangeCard(Card card)
    {
        _cardService.Change(card);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult AddCard()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCard(Card card)
    {
        _cardService.Add(card);
        return RedirectToAction(nameof(Index));
    }

}