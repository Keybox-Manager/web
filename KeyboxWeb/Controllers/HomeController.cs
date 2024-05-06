using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeyboxWeb.Models;
// using KeyboxWeb.Core.Interfaces.Helpers;
// using KeyboxWeb.Core.Models;

namespace KeyboxWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private readonly IHttpHelper<Account> _httpHelper;

    // public HomeController(ILogger<HomeController> logger, IHttpHelper<Account> httpHelper)
    // {
    //     _logger = logger;
    //     _httpHelper = httpHelper;
    // }

    // Главная, где представлены все карточки
    public IActionResult Index()
    {
        //var accounts = await _httpHelper.GetAsync(); //Пример использования api
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
