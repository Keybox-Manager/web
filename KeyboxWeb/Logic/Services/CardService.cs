using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public class CardService : ICardService
{
    // Логика карточек

    private readonly ICardRepository _repository;
    private readonly IRepository<Account> _account;
    private readonly IUserService _userService;
    private readonly ICategoryService _categoryService;

    public CardService(
        ICardRepository repository,
        IRepository<Account> account,
        IUserService userService,
        ICategoryService categoryService
    )
    {
        _repository = repository;
        _account = account;
        _userService = userService;
        _categoryService = categoryService;
    }

    public void AddAccount(Account account)
    {
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

    public void Add(Card card)
    {
        _repository.Add(card);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public void Change(Card card)
    {
        _repository.Update(card);
    }

    public IEnumerable<Card> Get(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            var category = _categoryService.GetFirst();
            return category.Cards;
        }

        var user = _userService.Get();
        return _repository.Get(name, user.Id);
    }

    public Card Get(int id)
    {
        return _repository.Get(id) ?? throw new ArgumentException($"Не найдена карточка по данному Id = {id}");
    }
}