using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public sealed class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;

    public CategoryService(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public void Add(Category category)
    {
        _repository.Add(category);
    }

    public void Change(Category category)
    {
        _repository.Update(category);
    }

    public void Delete(int id)
    {
        _repository?.Delete(id);
    }

    public IEnumerable<Category> Get()
    {
        return _repository.Get();
    }
}
