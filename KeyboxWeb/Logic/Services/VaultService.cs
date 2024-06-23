using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public class VaultService : IVaultService
{
    private readonly IRepository<Vault> _repository;
    private readonly IUserService _userService;

    public VaultService(IRepository<Vault> repository, IUserService userService) {
        _repository = repository;
        _userService = userService;
    }

    public void Add(Vault vault)
    {
        _repository.Add(vault);
    }

    public void Change(Vault vault)
    {
        _repository.Update(vault);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public Vault Get()
    {
        var user = _userService.Get();
        var vault = user.Vaults.First();
        return _repository.Get(vault.Id) ?? throw new ArgumentException($"Не найдена хранилище");
    }
}