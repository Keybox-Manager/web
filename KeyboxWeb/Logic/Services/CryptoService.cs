using KeyboxWeb.Logic.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace KeyboxWeb.Logic.Services;


public class CryptoService : ICryptoService{

    // Cryptography Logic

    // Функция хеширования мастер-пароля
    public string MasterPassToHash(string pass) {
        using(SHA256 sha256 = SHA256.Create()){
            byte[] bytes = Encoding.UTF8.GetBytes(pass);
            byte[] hash = sha256.ComputeHash(bytes);

            string hashPass = string.Concat(Array.ConvertAll(hash, x => x.ToString("x2")));
            return hashPass;
        }
    }


    // Функция шифрования обычных паролей
    public string EncryptPass(string key, string pass) {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(pass);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }


    // Функция расшифрования обычных паролей
    public string DeсryptPass(string key, string pass) {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(pass);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer)) {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read)) {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream)) {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

}