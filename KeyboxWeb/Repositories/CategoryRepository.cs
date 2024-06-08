using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Repositories;

public sealed class CategoryRepository : IRepository<Category>
{
    private readonly KeyboxContext _context;

    public CategoryRepository(KeyboxContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Categories
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Category>> GetAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Include(x=>x.Vault)
            .Include(x => x.Subcategories)
            .ToListAsync();
    }

    public async Task<Category?> GetAsync(int id)
    {
        return await _context.Categories
            .AsNoTracking()
            .Include(x => x.Vault)
            .Include(x => x.Subcategories)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Category model)
    {
        await _context.Categories
            .Where(w => w.Id == model.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.VaultId, model.VaultId)
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Description, model.Description)
            );
    }
}