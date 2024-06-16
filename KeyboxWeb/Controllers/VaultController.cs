using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Logic.Services;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Logic.Interfaces.Services;

namespace KeyboxWeb.Controllers;


public class VaultController : Controller {
    
    private readonly ICardService _cardService;
    public VaultController(ICardService cardService) {
        _cardService = cardService;
    }

    public IActionResult Index() {
        var cards = _cardService.Get();
        return View(cards);
    }
}