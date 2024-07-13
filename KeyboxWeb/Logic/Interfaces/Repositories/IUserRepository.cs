using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Delete(int id);
    User? Get(string login);
    void Update(User user);
}
