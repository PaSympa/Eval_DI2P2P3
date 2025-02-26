namespace PasswordManager.Api.Encryption;

/// <summary>
/// Defines an interface for encryption and decryption strategies.
/// </summary>
public interface IEncryptionStrategy
{
    /// <summary>
    /// Encrypts the provided plain text.
    /// </summary>
    /// <param name="plainText">Text to encrypt</param>
    /// <returns>Encrypted text</returns>
    string Encrypt(string plainText);

    /// <summary>
    /// Decrypts the provided encrypted text.
    /// </summary>
    /// <param name="cipherText">Text to decrypt</param>
    /// <returns>Decrypted text</returns>
    string Decrypt(string cipherText);
}