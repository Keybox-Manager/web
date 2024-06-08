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

    public async Task AddAsync(Subcategory model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Subcategories
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Subcategory>> GetAsync()
    {
        return await _context.Subcategories
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .ToListAsync();
    }

    public async Task<Subcategory?> GetAsync(int id)
    {
        return await _context.Subcategories
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Subcategory model)
    {
        await _context.Subcategories
            .Where(w => w.Id == model.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.CategoryId, model.CategoryId)
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Url, model.Url)
                .SetProperty(p => p.Notes, model.Notes)
                .SetProperty(p => p.Icon, model.Icon)
            );
    }
}