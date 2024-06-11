// Сервисы
namespace KeyboxWeb.Logic.Interfaces.Services;


public interface ICryptoService {
    string MasterPassToHash(string password);
    string EncryptPass(string key, string password);
    string DecryptPass(string key, string password);
}
