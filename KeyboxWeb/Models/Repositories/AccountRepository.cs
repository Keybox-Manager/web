using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Models.Repositories;

public sealed class AccountRepository : IRepository<Account>
{
    private readonly KeyboxContext _context;

    public AccountRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(Account model)
    {
        _context.Add(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Accounts
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<Account> Get()
    {
        return _context.Accounts
            .AsNoTracking()
            .Include(x => x.Subcategory)
            .ToList();
    }

    public Account? Get(int id)
    {
        return _context.Accounts
            .AsNoTracking()
            .Include(x => x.Subcategory)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Account model)
    {
        _context.Accounts
            .Where(w => w.Id == model.Id)
            .ExecuteUpdate(e => e
                .SetProperty(p => p.SubcategoryId, model.SubcategoryId)
                .SetProperty(p => p.Login, model.Login)
                .SetProperty(p => p.Email, model.Email)
                .SetProperty(p => p.Password, model.Password)
                .SetProperty(p => p.DateAdd, model.DateAdd)
                .SetProperty(p => p.DateUpdate, model.DateUpdate)
            );
    }
}