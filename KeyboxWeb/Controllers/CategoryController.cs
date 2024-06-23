using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Logic.Interfaces.Services;

namespace KeyboxWeb.Controllers;

public class CategoryController : Controller {
    private readonly ICategoryService _categoryService;

    // конструктор
    public CategoryController(ICategoryService categoryService) {
        _categoryService = categoryService;
    }

    // начало класса

    [HttpGet]
    public IActionResult AddCategory() {
        return View();
    }

    [HttpPost]
    public IActionResult AddCategory(Category ctgr) {
        _categoryService.Add(ctgr);
        return RedirectToAction("Index", "Vault");
    }

    
    public IActionResult DeleteCategory(int id) {
        _categoryService.Delete(id);
        return RedirectToAction("Index", "Vault");
    }


}