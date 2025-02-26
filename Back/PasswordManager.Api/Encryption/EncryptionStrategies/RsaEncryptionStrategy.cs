using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Api.Encryption.EncryptionStrategies;

/// <summary>
/// RSA encryption strategy for "Professional" applications.
/// </summary>
public class RsaEncryptionStrategy : IEncryptionStrategy
{
    private readonly RSA _rsa;

    public RsaEncryptionStrategy(RSA existingRsa)
    {
        _rsa = existingRsa;
    }

    public string Encrypt(string plainText)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedData = _rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
        return Convert.ToBase64String(encryptedData);
    }

    public string Decrypt(string cipherText)
    {
        byte[] dataToDecrypt = Convert.FromBase64String(cipherText);
        byte[] decryptedData = _rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.Pkcs1);
        return Encoding.UTF8.GetString(decryptedData);
    }
}