using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Repositories;

public interface ICardRepository
{
    void Add(Card card);
    void Delete(int id);
    IEnumerable<Card> Get(string search, int userId);
    Card? Get(int id);
    void Update(Card card);
}