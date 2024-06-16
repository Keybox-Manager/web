using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Models.Repositories;

public sealed class CardRepository : IRepository<Card>
{
    private readonly KeyboxContext _context;

    public CardRepository(KeyboxContext context)
    {
        _context = context;
    }

    public void Add(Card model)
    {
        _context.Add(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Cards
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public IEnumerable<Card> Get()
    {
        return _context.Cards
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .ToList();
    }

    public Card? Get(int id)
    {
        return _context.Cards
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Accounts)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Card model)
    {
        _context.Cards
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