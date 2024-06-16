using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Models.Repositories;

public sealed class CategoryRepository : IRepository<Category>
{
    private readonly KeyboxContext _context;

    public CategoryRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(Category model)
    {
        _context.AddAsync(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Categories
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<Category> Get()
    {
        return _context.Categories
            .AsNoTracking()
            .Include(x => x.Vault)
            .Include(x => x.Cards)
            .ToList();
    }

    public Category? Get(int id)
    {
        return _context.Categories
            .AsNoTracking()
            .Include(x => x.Vault)
            .Include(x => x.Cards)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Category model)
    {
        _context.Categories
            .Where(w => w.Id == model.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.VaultId, model.VaultId)
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Description, model.Description)
            );
    }
}