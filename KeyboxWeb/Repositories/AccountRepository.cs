using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Repositories;

public sealed class AccountRepository : IRepository<Account>
{
    private readonly KeyboxContext _context;

    public AccountRepository(KeyboxContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Account model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Accounts
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Account>> GetAsync()
    {
        return await _context.Accounts
            .AsNoTracking()
            .Include(x => x.Subcategory)
            .ToListAsync();
    }

    public async Task<Account?> GetAsync(int id)
    {
        return await _context.Accounts
            .AsNoTracking()
            .Include(x => x.Subcategory)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Account model)
    {
        await _context.Accounts
            .Where(w => w.Id == model.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.SubcategoryId, model.SubcategoryId)
                .SetProperty(p => p.Login, model.Login)
                .SetProperty(p => p.Email, model.Email)
                .SetProperty(p => p.Password, model.Password)
                .SetProperty(p => p.DateAdd, model.DateAdd)
                .SetProperty(p => p.DateUpdate, model.DateUpdate)
            );
    }
}