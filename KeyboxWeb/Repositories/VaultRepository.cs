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

    public async Task AddAsync(Vault model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Vaults
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Vault>> GetAsync()
    {
        return await _context.Vaults
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Categories)
            .ToListAsync();
    }

    public async Task<Vault?> GetAsync(int id)
    {
        return await _context.Vaults
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Vault model)
    {
        await _context.Vaults
            .Where(w => w.Id == model.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.UserId, model.UserId)
                .SetProperty(p => p.Name, model.Name)
            );
    }
}