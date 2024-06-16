using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Logic.Services;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Logic.Interfaces.Services;

namespace KeyboxWeb.Controllers;


public class VaultController : Controller {
    
    private readonly ICardService _cardService;
    private readonly ICategoryService _categoryService;
    public VaultController(ICardService cardService, ICategoryService categoryService) {
        _cardService = cardService;
        _categoryService = categoryService;
    }

    public IEnumerable<Category> GetCategories() {
        return _categoryService.Get();
    }

    public IActionResult Index() {
        var cards = _cardService.Get();
        return View(cards);
    }

    public IActionResult AddCard() {
        var card = _cardService.Add;
        return RedirectToAction("Index", "Vault");
    }
}