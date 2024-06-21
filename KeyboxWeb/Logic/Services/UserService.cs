using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace KeyboxWeb.Logic.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ICryptoService _cryptoService;
    private readonly HttpContext _httpContext;

    public UserService(IUserRepository repository, ICryptoService cryptoService, IHttpContextAccessor contextAccessor)
    {
        _repository = repository;
        _cryptoService = cryptoService;
        _httpContext = contextAccessor.HttpContext;
    }

    public bool TryRegister(User user)
    {
        if (IsAuthenticated())
        {
            return false;
        }

        if (IsLoginExist(user.Login))
        {
            return false;
        }

        var hash = _cryptoService.PasswordToHash(user.Password);
        user.Password = hash;
        _repository.Add(user);
        return true;
    }

    public bool TryLogin(string login, string password)
    {
        if (IsAuthenticated())
        {
            return false;
        }

        if (!IsLoginExist(login))
        {
            return false;
        }

        var hash = _cryptoService.PasswordToHash(password);
        var user = _repository.Get(login);
        if (!hash.Equals(user?.Password))
        {
            return false;
        }

        var claims = new List<Claim> { new(ClaimTypes.Name, login) };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        return true;
    }

    public void Logout()
    {
        _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public User Get()
    {
        if (!IsAuthenticated())
        {
            throw new InvalidOperationException("Пользователь не аутентифицирован");
        }

        string login = _httpContext.User.Identity.Name;
        return _repository.Get(login);
    }

    private bool IsAuthenticated()
    {
        var userIdentity = _httpContext.User.Identity;
        return userIdentity != null && userIdentity.IsAuthenticated;
    }

    private bool IsLoginExist(string login)
    {
        var user = _repository.Get(login);
        return user != null;
    }
}
