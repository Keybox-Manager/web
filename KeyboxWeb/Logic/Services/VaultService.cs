using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Services;

public class VaultService : IVaultService
{

    private readonly IRepository<Vault> _repository;
    public VaultService(IRepository<Vault> repository) {
        _repository = repository;
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
}