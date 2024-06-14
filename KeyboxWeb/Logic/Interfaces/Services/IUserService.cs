using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Services;

public interface IUserService
{
    bool TryRegister(User user);
    bool TryLogin(string login, string password);
    void Logout();
}
