using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public class CardService : ICardService
{
    // Логика карточек

    private readonly IRepository<Card> _repository;
    private readonly IRepository<Account> _account;

    public CardService(IRepository<Card> repository, IRepository<Account> account) {
        _repository = repository;
        _account = account;
    }

    public void AddAccount(Account account) {
        _account.Add(account);
    }
    public void DeleteAccount(int id)
    {
        _account.Delete(id);
    }

    public void ChangeAccount(Account account)
    {
        _account.Update(account);
    }

    public void Add(Card card) {
        _repository.Add(card);
    }

    public void Delete(int id) {
        _repository.Delete(id);
    }

    public void Change(Card card) {
        _repository.Update(card);
    }

    public Card Get(int id) {
        return _repository.Get(id) ?? throw new ArgumentException($"Не найдена карточка по данному Id = {id}");
    }

    public IEnumerable<Card> Get() {
        return _repository.Get();
    }
}