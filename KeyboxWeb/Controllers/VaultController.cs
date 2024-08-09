using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KeyboxWeb.Controllers;

[Authorize]
public class VaultController : Controller
{
    private readonly ICardService _cardService;
    private readonly ICategoryService _categoryService;

    public VaultController(ICardService cardService, ICategoryService categoryService)
    {
        _cardService = cardService;
        _categoryService = categoryService;
    }

    public IActionResult Index(int? categoryId)
    {
        Category category;

        if (categoryId != null)
        {
            category = _categoryService.Get((int)categoryId);
            return PartialView(category);
        }

        category = _categoryService.GetFirst();
        return View(category);
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
    public IActionResult AddCard(int categoryId)
    {
        var category = _categoryService.Get(categoryId);
        return View(category);
    }

    [HttpPost]
    public IActionResult AddCard(Card card)
    {
        _cardService.Add(card);
        return RedirectToAction(nameof(Index));
    }
}