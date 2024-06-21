using KeyboxWeb.Models.Entites;

namespace KeyboxWeb.Logic.Interfaces.Services;

public interface IVaultService {
    void Add(Vault vault);
    void Delete(int id);
    void Change(Vault vault);
    Vault Get();
}