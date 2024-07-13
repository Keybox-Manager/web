using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public sealed class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;
    private readonly IVaultService _vaultService;

    public CategoryService(IRepository<Category> repository, IVaultService vaultService)
    {
        _repository = repository;
        _vaultService = vaultService;
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

    public Category Get(int id)
    {
        return _repository.Get(id) ?? throw new ArgumentException($"Не найдена категория по данному Id = {id}");
    }

    public Category GetFirst()
    {
        var vault = _vaultService.GetFirst();
        var category = vault.Categories.First();
        return Get(category.Id);
    }
}
