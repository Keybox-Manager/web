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

    // Получаем список всех категорий (для master-view страницы)
    public IEnumerable<Category> GetCategories() {
        return _categoryService.Get();
    }


    public IActionResult Index() {
        var cards = _cardService.Get();
        return View(cards);
    }

    public IActionResult DeleteCard(int id) {
        _cardService.Delete(id);
        return RedirectToAction("Index");

    }


    public IActionResult ChangeCard(Card card) {
        _cardService.Change(card);
        return RedirectToAction("Index");
    }
    
}