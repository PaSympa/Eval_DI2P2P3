using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;
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
    
    public PasswordService(IPasswordRepository passwordRepository)
    {
        _passwordRepository = passwordRepository;
    }
    
    public async Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync()
    {
        var passwords = await _passwordRepository.GetAllPasswordsAsync();
        return passwords.Select(PasswordMapper.ToDto);
    }

    public async Task<PasswordDto> GetPasswordByIdAsync(int id)
    {
        var password = await _passwordRepository.GetPasswordByIdAsync(id);
        return PasswordMapper.ToDto(password);    }

    public async Task AddPasswordAsync(CreatePasswordDto password)
    {
        var passwordEntity = PasswordMapper.ToEntity(password);

        // TODO Add encrypthion logic: passwordEntity.EncryptedPassword = Encrypt(passwordEntity.EncryptedPassword, appType);

        await _passwordRepository.AddPasswordAsync(passwordEntity);
    }

    public async Task DeletePasswordAsync(int id)
    {
        await _passwordRepository.DeletePasswordAsync(id);
    }
}