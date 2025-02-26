using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;
using PasswordManager.Api.Encryption;
using PasswordManager.Api.Encryption.EncryptionStrategies;
using PasswordManager.Api.Mappers;
using PasswordManager.Api.Repositories.Interfaces;
using PasswordManager.Api.Services.Interfaces;

namespace PasswordManager.Api.Services;

/// <summary>
/// Implementation of IPasswordService to manage password business logic.
/// </summary>
public class PasswordService : IPasswordService
{
    private readonly IPasswordRepository _passwordRepository;
    private readonly AesEncryptionStrategy _aesStrategy;
    private readonly RsaEncryptionStrategy _rsaStrategy;
    
    public PasswordService(IPasswordRepository passwordRepository, AesEncryptionStrategy aesStrategy, RsaEncryptionStrategy rsaStrategy)
    {
        _passwordRepository = passwordRepository;
        _aesStrategy = aesStrategy;
        _rsaStrategy = rsaStrategy;
    }
    
    public async Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync()
    {
        var passwords = await _passwordRepository.GetAllPasswordsAsync();

        // For each password, choose the right strategy based on the ApplicationType,
        // then decrypt the stored password.
        var passwordDtos = passwords.Select(p =>
        {
            IEncryptionStrategy decryptionStrategy = p.Application.ApplicationType == ApplicationType.Public
                ? _aesStrategy
                : _rsaStrategy;

            // Decrypt the encrypted password.
            string decryptedPassword = decryptionStrategy.Decrypt(p.EncryptedPassword);

            // Map to DTO and assign the decrypted value (here we assume you have a property for that).
            var dto = PasswordMapper.ToDto(p);

            dto.EncryptedPassword = decryptedPassword;
            return dto;
        });

        return passwordDtos;
    }
    
    public async Task<IEnumerable<PasswordDto>> GetEncryptedPasswordsAsync()
    {
        var passwords = await _passwordRepository.GetAllPasswordsAsync();

        var passwordDtos = passwords.Select(p => PasswordMapper.ToDto(p));

        return passwordDtos;
    }

    public async Task<PasswordDto> GetEncryptedPasswordByIdAsync(int id)
    {
        var password = await _passwordRepository.GetPasswordByIdAsync(id);
        if (password == null)
            return null;

        var dto = PasswordMapper.ToDto(password);
        return dto;
    }

    public async Task<PasswordDto> GetPasswordByIdAsync(int id)
    {
        var password = await _passwordRepository.GetPasswordByIdAsync(id);
        if (password == null)
            return null;

        IEncryptionStrategy decryptionStrategy = password.Application.ApplicationType == ApplicationType.Public
            ? _aesStrategy
            : _rsaStrategy;

        string decryptedPassword = decryptionStrategy.Decrypt(password.EncryptedPassword);
        var dto = PasswordMapper.ToDto(password);
        
        dto.EncryptedPassword = decryptedPassword;
        return dto;  
    }

    public async Task AddPasswordAsync(CreatePasswordDto password, ApplicationType appType)
    {
        // Convert DTO to entity.
        var passwordEntity = PasswordMapper.ToEntity(password);

        // Select the encryption strategy based on the provided application type.
        IEncryptionStrategy encryptionStrategy = appType == ApplicationType.Public
            ? _aesStrategy
            : _rsaStrategy;

        // Encrypt the plain password.
        passwordEntity.EncryptedPassword = encryptionStrategy.Encrypt(password.PlainPassword);

        await _passwordRepository.AddPasswordAsync(passwordEntity);
    }

    public async Task DeletePasswordAsync(int id)
    {
        await _passwordRepository.DeletePasswordAsync(id);
    }
}