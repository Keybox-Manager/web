using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Repositories;

public sealed class UserRepository : IRepository<User>
{
    private readonly KeyboxContext _context;

    public UserRepository(KeyboxContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Users
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.Vaults)
            .ToListAsync();
    }

    public async Task<User?> GetAsync(int id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.Vaults)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(User model)
    {
        await _context.Users
            .Where(w => w.Id == model.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.Name, model.Name)
                .SetProperty(p => p.Password, model.Password)
                .SetProperty(p => p.PasswordHint, model.PasswordHint)
                .SetProperty(p => p.Email, model.Email)
            );
    }
}