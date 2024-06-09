using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Repositories;

public sealed class SubcategoryRepository : IRepository<Subcategory>
{
    private readonly KeyboxContext _context;

    public SubcategoryRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(Subcategory model)
    {
        _context.Add(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Subcategories
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<Subcategory> Get()
    {
        return _context.Subcategories
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .ToList();
    }

    public Subcategory? Get(int id)
    {
        return _context.Subcategories
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Subcategory model)
    {
        _context.Subcategories
            .Where(w => w.Id == model.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.CategoryId, model.CategoryId)
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Url, model.Url)
                .SetProperty(p => p.Notes, model.Notes)
                .SetProperty(p => p.Icon, model.Icon)
            );
    }
}