using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Models;
using KeyboxWeb.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KeyboxWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    // Главная, где представлены все карточки
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    // Карточка, где вся информация об УЗ
    public IActionResult Card()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
