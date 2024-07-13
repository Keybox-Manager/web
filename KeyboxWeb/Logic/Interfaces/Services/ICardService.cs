using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Services;

public interface ICardService
{
    // Для аккаунтов (в карточке)
    void AddAccount(Account account);
    void DeleteAccount(int id);
    void ChangeAccount(Account account);

    // Функции самих карточек
    void Add(Card card);
    void Delete(int id);
    void Change(Card card);
    IEnumerable<Card> Get(string? name);
    Card Get(int id);
}
