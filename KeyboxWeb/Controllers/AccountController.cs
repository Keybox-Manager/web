using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace KeyboxWeb.Controllers;

public sealed class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string login, string password)
    {
        if (_userService.TryLogin(login, password))
        {
            return RedirectToAction("Index", "Vault");
        }

        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
        if (_userService.TryRegister(user))
        {
            return RedirectToAction(nameof(Login));
        }

        return View();
    }

    public IActionResult Logout()
    {
        _userService.Logout();
        return RedirectToAction(nameof(Login));
    }
}