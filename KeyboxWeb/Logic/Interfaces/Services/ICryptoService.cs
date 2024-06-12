// Сервисы
namespace KeyboxWeb.Logic.Interfaces.Services;


public interface ICryptoService {
    string PasswordToHash(string password);
    string EncryptPassword(string key, string password);
    string DecryptPassword(string key, string password);
}
