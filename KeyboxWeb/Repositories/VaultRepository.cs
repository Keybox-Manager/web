using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Repositories;

public sealed class VaultRepository : IRepository<Vault>
{
    private readonly KeyboxContext _context;

    public VaultRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(Vault model)
    {
        _context.Add(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Vaults
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<Vault> Get()
    {
        return _context.Vaults
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Categories)
            .ToList();
    }

    public Vault? Get(int id)
    {
        return _context.Vaults
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Categories)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Vault model)
    {
        _context.Vaults
            .Where(w => w.Id == model.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.UserId, model.UserId)
                .SetProperty(p => p.Name, model.Name)
            );
    }
}