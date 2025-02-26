using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Api.Encryption.EncryptionStrategies;

/// <summary>
/// AES encryption strategy for "Public" applications.
/// </summary>
public class AesEncryptionStrategy : IEncryptionStrategy
{
    private readonly byte[] Key = "0123456789ABCDEF0123456789ABCDEF"u8.ToArray(); // 32 octets pour AES-256
    private readonly byte[] IV = "ABCDEF0123456789"u8.ToArray();  // 16 octets

    public string Encrypt(string plainText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}