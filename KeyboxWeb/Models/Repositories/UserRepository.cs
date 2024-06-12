using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Models.Repositories;

public sealed class UserRepository : IRepository<User>
{
    private readonly KeyboxContext _context;

    public UserRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(User model)
    {
        _context.Add(model);
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

    public User? Get(int id)
    {
        return _context.Users
            .AsNoTracking()
            .Include(x => x.Vaults)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(User model)
    {
        _context.Users
            .Where(w => w.Id == model.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Password, model.Password)
                .SetProperty(p => p.PasswordHint, model.PasswordHint)
                .SetProperty(p => p.Email, model.Email)
            );
    }
}