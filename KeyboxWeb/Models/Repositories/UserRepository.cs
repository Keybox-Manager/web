using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Models.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly KeyboxContext _context;

    public UserRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Users
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<User> Get()
    {
        return _context.Users
            .AsNoTracking()
            .Include(x => x.Vaults)
            .ToList();
    }

    public User? Get(string login)
    {
        return _context.Users
            .AsNoTracking()
            .Include(x => x.Vaults)
            .FirstOrDefault(x => x.Login == login);
    }

    public void Update(User user)
    {
        _context.Users
            .Where(w => w.Id == user.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.Name, user.Name)
                .SetProperty(p => p.Login, user.Login)
                .SetProperty(p => p.Password, user.Password)
                .SetProperty(p => p.PasswordHint, user.PasswordHint)
            );
    }
}