// Сервисы
namespace KeyboxWeb.Logic.Interfaces.Services;


public interface ICryptoService {
    string MasterPassToHash(string pass);
    string EncryptPass(string key, string pass);
    string DecryptPass(string key, string pass);
}
