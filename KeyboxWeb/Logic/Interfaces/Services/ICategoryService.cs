using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Services;

public interface ICategoryService
{
    void Add(Category category);
    void Change(Category category);
    void Delete(int id);
    Category Get(int id);
    Category GetFirst();
}
