using KeyboxWeb.Logic.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace KeyboxWeb.Logic.Services;


public class CryptoService : ICryptoService{

    // Cryptography Logic

    // Функция хеширования мастер-пароля
    public string PasswordToHash(string password) {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }

    // Функция шифрования обычных паролей
    public string EncryptPassword(string key, string password) {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new())
            {
                using (CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new(cryptoStream))
                    {
                        streamWriter.Write(password);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    // Функция расшифрования обычных паролей
    public string DecryptPassword(string key, string password) {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(password);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new(buffer)) {
                using (CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read)) {
                    using (StreamReader streamReader = new(cryptoStream)) {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}